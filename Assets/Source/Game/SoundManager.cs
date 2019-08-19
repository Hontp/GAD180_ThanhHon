using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour
{
    public bool _moving;
    public bool _firing;
    public bool _playerCollide;
    public bool _enemyCollide;
    public int _enemyCount = 0;
    public int _playerWeapon = 0;
    public int _playerCollision;
    public int _enemyCollision;
    public string _projectileAssignment;
    private string[] _projectileList = new string[3];
    private int _projectileType;
    public float _healthCount = 10;
    public bool _clicked;
    public bool _menuContinue;
    public bool _menuConclude;
    public bool _musicPlaying;

    FMOD.Studio.EventInstance _music;
    FMOD.Studio.EventInstance _playerProp;
    FMOD.Studio.EventInstance[] _weaponType = new FMOD.Studio.EventInstance[3];
    FMOD.Studio.EventInstance[] _collisionType = new FMOD.Studio.EventInstance[3];
    FMOD.Studio.EventInstance _lowHealth;
    FMOD.Studio.EventInstance _playerDeath;
    public FMOD.Studio.EventInstance _menuClick;
    public FMOD.Studio.EventInstance _menuExit;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    //Everything Else
    void Start()
    {
        MusicSet();
        MoveSet();
        //ProjectileTypeSet();
        WeaponSet();
        CollisionSet();
        //HealthSet();
        MenuSet();
    }
    void Update()
    {
        MusicAdapt();
        MusicCheck();
        MoveCheck();
        //ProjectileTypeCheck();
        WeaponCheck();
        CollisionCheck();
        //HealthCheck();
        //MenuCheck();
    }

    //Music
    void MusicSet()
    {
        if (!_musicPlaying)
        {
            _music = FMODUnity.RuntimeManager.CreateInstance("event:/AdapMusic/Combat");
            _music.start();
            _musicPlaying = true;
        }
    }
    void MusicCheck()
    {
        if (_enemyCount > 10)
        {
            _enemyCount = 10;
        }
        if (_healthCount < 0)
        {
            _healthCount = 0;
        }
        _music.setParameterByName("Enemies", _enemyCount);
        _lowHealth.setParameterByName("Health", _healthCount);
    }

    //Moving Sounds
    public void MoveSet()
    {
        _playerProp = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player_Prop");
        _playerProp.setParameterByName("Moving", 0);
    }
    void MoveCheck()
    {
        if (Input.GetKeyDown("w"))
        {
            _playerProp.setParameterByName("Moving", 1);
            _playerProp.start();
        }
        else if (Input.GetKeyUp("w"))
        {
            _playerProp.setParameterByName("Moving", 0);
        }
    }

    //ProjectileTypeSet
    void ProjectileTypeSet()
    {
        _projectileList[0] = "Torpedo";
        _projectileList[1] = "Laser";
        _projectileList[2] = "Bullet";
        _projectileAssignment = _projectileList[0];
    }
    void ProjectileTypeCheck()
    {
        _projectileType = 0;

        for (int i = 0; i < 3; i++)
        {
            if (_projectileAssignment != _projectileList[_projectileType])
            {
                _projectileType++;
            }
            else if (_projectileAssignment == _projectileList[_projectileType])
            {
                _playerWeapon = _projectileType;
            }
            else
            {
                _playerWeapon = 0;
            }
        }
    }

    //Player Weapons
    void WeaponSet()
    {
        _weaponType[0] = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Weap_Torp");
        _weaponType[1] = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Weap_Laser");
        _weaponType[2] = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Weap_Bullet");
    }
    void WeaponCheck()
    {
        if (_firing)
        {
            _weaponType[_playerWeapon].start();
            _firing = false;
        }
        else
        {
            
        }
    }

    //Player Collision
    void CollisionSet()
    {
        _collisionType[0] = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Hit_Physical");
        _collisionType[1] = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Hit_Laser");
        _collisionType[2] = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Hit_Explosion");
    }
    void CollisionCheck()
    {
        if (_playerCollide)
        {
            _collisionType[_playerCollision].start();
            _playerCollide = false;
        }
        else if (_enemyCollide)
        {
            _collisionType[_enemyCollision].start();
            _enemyCollide = false;
        }
        else
        {
        }
    }

    void HealthSet()
    {
        _lowHealth = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player_LowHP");
        _playerDeath = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player_Death");
    }
    void HealthCheck()
    {
        _lowHealth.setParameterByName("Health", _healthCount);
        if (_healthCount > 2 && _healthCount < 6)
        {
            _lowHealth.start();
        }
        else if (_healthCount > 0 && _healthCount <= 2)
        {
            _lowHealth.start();
        }
        else if (_healthCount <= 0)
        {
            _healthCount = 0;
            _playerDeath.start();
        }
    }

    void MenuSet()
    {
        _menuClick = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/UI_Click");
        _menuExit = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/UI_Finish");
        _clicked = false;
    }

    public void MenuClick()
    {
        _menuClick.start();
    }

    public void MenuClose()
    {
        _menuExit.start();
    }

    /*
    void MenuCheck()
    {
        if (_clicked)
        {
            if(_menuContinue)
            {
                _menuClick.start();
                _clicked = false;
            }
            else if (_menuConclude)
            {
                _menuExit.start();
                _clicked = false;
            }
            else
            {
                _clicked = false;
            }
        }
        else
        {

        }
    }*/

    void MusicAdapt()
    {
        if (Input.GetKeyDown("up"))
        {
            _enemyCount++;
        }
        else if (Input.GetKeyDown("down"))
        {
            _enemyCount--;
        }
        else if (Input.GetKeyDown("right"))
        {
            _healthCount++;
        }
        else if (Input.GetKeyDown("left"))
        {
            _healthCount--;
        }
    }
}
