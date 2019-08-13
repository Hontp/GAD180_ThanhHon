using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public bool _moving;
    public bool _firing;
    public bool _playerCollide;
    public int _enemyCount;
    public int _playerWeapon;
    public int _playerCollision;
    public string _projectileAssignment;
    private string[] _projectileList = new string[3];
    private int _projectileType;
    float _maxHealth;
    public float _currentHealth;
    private float _healthCount;

    FMOD.Studio.EventInstance _music;
    FMOD.Studio.EventInstance _playerProp;
    FMOD.Studio.EventInstance[] _weaponType = new FMOD.Studio.EventInstance[3];
    FMOD.Studio.EventInstance[] _collisionType = new FMOD.Studio.EventInstance[3];
    FMOD.Studio.EventInstance _lowHealth;
    FMOD.Studio.EventInstance _playerDeath;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //Everything Else
    void Start()
    {
        MusicSet();
        MoveSet();
        ProjectileTypeSet();
        WeaponSet();
        CollisionSet();
        HealthSet();
    }
    void Update()
    {
        MusicCheck();
        MoveCheck();
        ProjectileTypeCheck();
        WeaponCheck();
        CollisionCheck();
        HealthCheck();
    }

    //Music
    void MusicSet()
    {
        _music = FMODUnity.RuntimeManager.CreateInstance("event:/AdapMusic/Combat");
        _music.start();
    }
    void MusicCheck()
    {
        if (_enemyCount > 10)
        {
            _enemyCount = 10;
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
            _playerProp.start();
            _playerProp.setParameterByName("Moving", 1);
        }
        else if (Input.GetKeyUp("w"))
        {
            _playerProp.setParameterByName("Moving", 0);
        }
    }

    //ProjectileTypeSet
    void ProjectileTypeSet()
    {
        _projectileList[0] = "Bullet";
        _projectileList[1] = "Laser";
        _projectileList[2] = "Torpedo";
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
        _weaponType[0] = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Weap_Bullet");
        _weaponType[1] = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Weap_Laser");
        _weaponType[2] = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Weap_Torp");
    }
    void WeaponCheck()
    {
        if (_firing)
        {
            _weaponType[_playerWeapon].start();
            _firing = false;
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
    }

    void HealthSet()
    {
        _maxHealth = _currentHealth;
        _lowHealth = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player_LowHP");
        _playerDeath = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player_Death");
    }
    void HealthCheck()
    {
        _healthCount = (_currentHealth / _maxHealth) * 10;
        _lowHealth.setParameterByName("Health", _healthCount);
        if (_healthCount > 2 && _healthCount < 5)
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
}
