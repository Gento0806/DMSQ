using System;
using System.Collections.Generic;
using UnityEngine;

using CriWare;

public class ADXSoundManager: IDisposable
{
    // ExPlayerを管理する変数
    private Dictionary<string, MyExPlayer> _exPlayers;

    private CriAtomEx3dListener _ex3dListener;    // ExListener
    private Transform _listenerTransform; // Listener用の座標

    // ========================================================================================
    // ADXSoundManagerをシングルトンとするための記述
    
    private static ADXSoundManager _instance;

    public void SetCategoryVolume(string categoryName, float volume)
    {
        CriAtomExCategory.SetVolume(categoryName, volume);
    }

    // ADXSoundManager.Instanceという記述で、どこからでもADXSoundManagerにアクセス可能
    public static ADXSoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ADXSoundManager();
            }
            return _instance;
        }
    }

    // コンストラクタをプライベートにして外部からのインスタンス化を防ぐ
    private ADXSoundManager()
    {
        _exPlayers = new Dictionary<string, MyExPlayer>();
        _ex3dListener = new CriAtomEx3dListener();
        // 自動的に作られるリスナーを削除しておく
        CriAtomListener.DestroyDummyNativeListener();

        // --------------------------------------------------------------------------------
        // ADXSoundManagerで必要な初期化コードがあれば適宜ここのコードブロックに書くとよい
        // 
        // int myFavoriteThings = 100;
        // myFavoriteThings += 10;
        // --------------------------------------------------------------------------------
    }
    // ADXSoundManagerのシングルトンの記述はここまで
    // ========================================================================================

    // リソースの破棄
    public void Dispose()
    {
        // すべてのexPlayerを破棄
        foreach (var exPlayer in _exPlayers.Values)
        {
            exPlayer.Dispose();
        }
        _exPlayers.Clear();

        // Ex3dListenerの破棄
        _ex3dListener.Dispose();

        GC.SuppressFinalize(this);
    }

    private MyExPlayer GetOrCreateExPlayer(string key)
    {
        if (!_exPlayers.ContainsKey(key))
        {
            // keyに対応する名前のExPlayerがまだ存在しないなら作る
            _exPlayers[key] = new MyExPlayer();
        }

        return _exPlayers[key];
    }

    public void PlaySound(string key, CriAtomExAcb cueSheet, string cueName, Transform sourceTransform, bool is3D)
    {
        // key: "BGMExPlayer", "Bullet"
        // PlaySound("BGMExPlayer", cueReference.acbassets.handle, cueRefenrece.cueName, this.gameObject.transform, true);
        MyExPlayer exPlayer = GetOrCreateExPlayer(key);
        if (is3D)
        {
            exPlayer.SetSourceTransform(sourceTransform);
            exPlayer.Set3dListener(_ex3dListener);
        }
        exPlayer.Play(cueSheet, cueName, is3D);
    }

    public void PlaySound(string key, CriAtomExAcb cueSheet, int cueId, Transform sourceTransform, bool is3D)
    {
        MyExPlayer exPlayer = GetOrCreateExPlayer(key);
        if (is3D)
        {
            exPlayer.SetSourceTransform(sourceTransform);
            exPlayer.Set3dListener(_ex3dListener);
        }
        exPlayer.Play(cueSheet, cueId, is3D);
    }

    public void StopSound(string key)
    {
        if (!_exPlayers.ContainsKey(key))
        {
            return;
        }

        MyExPlayer exPlayer = GetOrCreateExPlayer(key);
        exPlayer.Stop();
    }

    // exPlayerと紐づいているex3dSourceのポジションをアップデートする関数
    // 例えばGameObejct側のUpdate()でこのADXSoundManager.Instance.UpdateSoundPosition()という記述で更新する
    public void UpdateSoundPosition(string key)
    {
        if (_exPlayers.TryGetValue(key, out MyExPlayer exPlayer))
        {
            exPlayer.Update();
        }
    }

    // リスナーとして使用するTransformを設定(カメラやキャラクターなど)
    public void SetListenerTransform(Transform transform)
    {
        _listenerTransform = transform;
    }    

    // 紐づいているGameObjectのUpdate()でこのポジションの更新を呼ぶ
    public void UpdateListenerPosition()
    {
        if (_listenerTransform != null)
        {
            // ここでは座標の更新のみを行っている
            // リスナーの向きを考慮したい場合は_ex3dListener.SetOrientationを使用することで可能
            _ex3dListener.SetPosition(_listenerTransform.position.x, _listenerTransform.position.y, _listenerTransform.position.z);
            _ex3dListener.Update();
        }
    }

    public void SetSelectorLabelForAllExPlayer(string selectorName, string selectorLabelName)
    {
        foreach (MyExPlayer exPlayer in _exPlayers.Values)
        {
            exPlayer.SetSelectorLabel(selectorName, selectorLabelName);
        }
    }

    public void SetSelectorLabel(string key, string selectorName, string selectorLabelName)
    {
        _exPlayers[key].SetSelectorLabel(selectorName, selectorLabelName);
    }



    // ========================================================================================
    // ここからMyExPlayerクラスの記述

    // MyExPlayerクラスをADXSoundManagerを介さずに触れないようにprivateにする。(内部クラスとして定義する)
    private class MyExPlayer
    {
        public void SetSelectorLabel(string selectorName, string selectorLabelName)
        {
            _exPlayer.SetSelectorLabel(selectorName, selectorLabelName);
        }

        private CriAtomExPlayer _exPlayer;
        private CriAtomEx3dSource _ex3dSource;

        // 音源となるGameObjectの座標
        private Transform _sourceTransform;

        // コンストラクタ. UnityでいうAwake()やStart()と近い、初期化処理
        public MyExPlayer()
        {
            _exPlayer = new CriAtomExPlayer();
            _ex3dSource = new CriAtomEx3dSource();
        }

        public void SetSourceTransform(Transform sourceTransform)
        {
            _sourceTransform = sourceTransform;
            _exPlayer.Set3dSource(_ex3dSource);
        }

        public void Set3dListener(CriAtomEx3dListener listener)
        {
            _exPlayer.Set3dListener(listener);
        }

        public void Play(CriAtomExAcb cueSheet, string cueName, bool is3D)
        {
            _exPlayer.SetCue(cueSheet, cueName);

            if (is3D && _sourceTransform != null)
            {
                _ex3dSource.SetPosition(_sourceTransform.position.x, _sourceTransform.position.y, _sourceTransform.position.z);
            }

            // 再生
            CriAtomExPlayback playback = _exPlayer.Start();
            _exPlayer.Update(playback); // SourceとPlayerの関連付けのUpdateもここ
            _ex3dSource.Update();

            // --------------------------------------------------------------------------------------------- 
            // ブロック再生は_exPlayer.Start();の返り値であるCriAtomExPlaybackを介して、
            // exPlayback.SetNextBlockIndex(10);
            // といったように使用するため、必要であれば適宜exPlaybackを使用すると良い。
            // また、アクション機能のブロック遷移先指定アクションを使えば、exPlaybackは不要
            // 
            // ExPlaybackを使用したい場合は、関数の返り値の型とともに、以下のように書き換えるとよい。
            // CriAtomExPlayback exPlayback = criAtomExPlayer.Start();
            // return exPlayback;
            // --------------------------------------------------------------------------------------------- 

        }

        public void Play(CriAtomExAcb cueSheet, int cueId, bool is3D)
        {
            _exPlayer.SetCue(cueSheet, cueId);

            if (is3D && _sourceTransform != null)
            {
                _ex3dSource.SetPosition(_sourceTransform.position.x, _sourceTransform.position.y, _sourceTransform.position.z);
                _ex3dSource.Update();
            }

            CriAtomExPlayback playback = _exPlayer.Start();
            _exPlayer.Update(playback); // SourceとPlayerの関連付けのUpdateもここ
            _ex3dSource.Update();
        }

        public void Update()
        {
            if (_sourceTransform != null)
            {
                _ex3dSource.SetPosition(_sourceTransform.position.x, _sourceTransform.position.y, _sourceTransform.position.z);
                _ex3dSource.Update();
            }
        }

        public void Stop()
        {
            _exPlayer.Stop();
        }

        public void Dispose()
        {
            _exPlayer.Dispose();
            _ex3dSource.Dispose();
        }
    }
}
