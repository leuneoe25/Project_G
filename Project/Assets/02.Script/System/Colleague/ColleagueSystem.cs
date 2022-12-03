using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColleagueType
{
    Attack,
    Debuff,
    Support
}
public enum ColleagueClub
{
    Archer,
    Clean,
    Kendo,
    Boxing,
    Sea,
}
public class Colleague
{
    private string _name;
    public string name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    private int _rank;
    public int rank
    {
        get
        {
            return _rank;
        }
        set
        {
            _rank = value;
        }
    }
    private int[] _training;
    public int[] training
    {
        get
        {
            return _training;
        }
        set
        {
            _training = value;
        }
    }

    private ColleagueType _type;
    public ColleagueType type
    {
        get
        {
            return _type;
        }
        set
        {
            _type = value;
        }
    }
    private ColleagueClub _club;
    public ColleagueClub club
    {
        get
        {
            return _club;
        }
        set
        {
            _club = value;
        }
    }

    public Colleague(string name, int rank, int[] _training, ColleagueClub club)
    {
        _name = name;
        _rank = rank;
        training = _training;
        _club = club;
        switch (_club)
        {
            case ColleagueClub.Archer:
            case ColleagueClub.Clean:
            case ColleagueClub.Kendo:
                _type = ColleagueType.Attack;
                break;
            case ColleagueClub.Boxing:
            case ColleagueClub.Sea:
                _type = ColleagueType.Debuff;
                break;
        }
    }
}
public class ColleagueSystem : MonoBehaviour
{
    #region Singleton
    private static ColleagueSystem instance = null;
    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static ColleagueSystem Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    #endregion
    private int ColleagueCount;
    List<Colleague> colleagues = new List<Colleague>();
    void Start()
    {
        AddColleague("사이라", 3, new int[3] { 1, 2, 3 }, ColleagueClub.Archer);
        AddColleague("다이라", 2, new int[3] { 1, 2, 3 }, ColleagueClub.Boxing);
    }

    private void AddColleague(string name, int rank, int[] _training, ColleagueClub club)
    {
        Colleague Character = new Colleague(name, rank,_training, club);
        colleagues.Add(Character);
    }
    public List<Colleague> Getcolleagues()
    {
        return colleagues;
    }
}
