using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public enum ColleagueType
{
    Attack,
    Support,
    Debuff,
}
public enum ColleagueClub
{
    Archer,
    Kendo,
    Clean,
    Sea,
    Science,
    Boxing,
    Band,
    Cooking,
    Library
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
    public int trainingCount;

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
            case ColleagueClub.Kendo:
            case ColleagueClub.Clean:
                _type = ColleagueType.Attack;
                break;
            case ColleagueClub.Sea:
            case ColleagueClub.Science:
            case ColleagueClub.Boxing:
                _type = ColleagueType.Support;
                break;
            case ColleagueClub.Band:
            case ColleagueClub.Cooking:
            case ColleagueClub.Library:
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
    //List<Colleague> Deck;
    Dictionary<int, List<Colleague>> DeckMap = new Dictionary<int, List<Colleague>>();


    void Start()
    {
        AddColleague("사이라", 3, new int[3] { 0, 0, 0 }, ColleagueClub.Archer);
        AddColleague("다이라", 2, new int[3] { 0, 0, 0 }, ColleagueClub.Boxing);
        DeckMap.Add(0, new List<Colleague>());
        DeckMap[0].Add(colleagues[0]);
        DeckMap[0].Add(colleagues[1]);




        DeckMap.Add(1, new List<Colleague>());
        DeckMap.Add(2, new List<Colleague>());
        DeckMap.Add(3, new List<Colleague>());
        DeckMap.Add(4, new List<Colleague>());
    }

    private void AddColleague(string name, int rank, int[] _training, ColleagueClub club)
    {
        Colleague Character = new Colleague(name, rank,_training, club);
        colleagues.Add(Character);
    }

    public void Add(int DeckNum, int index,Colleague colleague)
    {
        if (DeckMap[DeckNum].Count <= 5)
        {
            DeckMap[DeckNum][index] = colleague;
        }
    }
    public void Swap(int DeckNum, int a,int y)
    {
        Colleague colleague = DeckMap[DeckNum][a];
        DeckMap[DeckNum][a] = DeckMap[DeckNum][y];
        DeckMap[DeckNum][y] = colleague;
    }
    public void DeckClear(int DeckNum)
    {
        DeckMap[DeckNum] = new List<Colleague>();
        for (int i = DeckMap[DeckNum].Count; i < 5; i++)
        {
            DeckMap[DeckNum].Add(null);
        }
    }
    public bool IsInList(int index, string name)
    {
        for (int i = 0; i < DeckMap[index].Count; ++i)
        {
            if (DeckMap[index][i] == null)
                continue;
            if (DeckMap[index][i].name == name)
            {
                return true;
            }
        }
        return false;
    }
    public List<Colleague> Getcolleagues()
    {
        return colleagues;
    }
    public List<Colleague> GetDeck(int index)
    {
        return DeckMap[index];
    }
}
