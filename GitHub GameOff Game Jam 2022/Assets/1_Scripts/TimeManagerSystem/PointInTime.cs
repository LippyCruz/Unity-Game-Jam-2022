using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Season {    
    Summer, Fall, Winter, Spring
}

public class PointInTime {

    // hardcoded definitions of how time should progress
    private static readonly int _firstYear = 1;
    private static readonly Season[] _seasonInYearSequence = { Season.Summer, Season.Fall, Season.Winter, Season.Spring };
    private static readonly int _firstRoundInSeason = 1;
    private static readonly int _lastRoundInSeason = 3;

    PointInTime(int year, Season seasonInYear, int monthInSeason) {
        Year = year;
        SeasonInYear = seasonInYear;
        RoundInSeason = monthInSeason;
    }

    public int Year { get; private set; }
    public Season SeasonInYear { get; private set; }
    public int RoundInSeason { get; private set; }

    public static PointInTime GenerateFirstPointInTime() {
        return new PointInTime(_firstYear, _seasonInYearSequence[0], _firstRoundInSeason);
    }

    public PointInTime GenerateNext() {

        int     newYear;
        Season  newSeason;
        int     newRound;

        if (IsLastRoundOfSeason() && IsLastSeasonOfYear()) { // if at end of year
            newYear     = Year + 1;
            newSeason   = GetNextSeason(SeasonInYear);
            newRound    = GetNextRound(RoundInSeason);
        } else if (IsLastRoundOfSeason()) { // if at end of season but not end of year
            newYear     = Year;
            newSeason   = GetNextSeason(SeasonInYear);
            newRound    = GetNextRound(RoundInSeason);
        } else { // if just within a season
            newYear     = Year;
            newSeason   = SeasonInYear;
            newRound    = GetNextRound(RoundInSeason);
        }

        return new PointInTime(newYear, newSeason, newRound);
    }

    public override string ToString() => "Year " + Year + ", " + SeasonInYear.ToString() + ", Month " + RoundInSeason;
    public Season GetNextSeason() => GetNextSeason(SeasonInYear);
    public int GetRoundsRemainingInSeason() => _lastRoundInSeason - RoundInSeason;


    private static int GetSeasonIndex(Season s) => Array.IndexOf(_seasonInYearSequence, s);

    private bool IsLastRoundOfSeason() => IsLastRoundOfSeason(RoundInSeason);
    private bool IsLastSeasonOfYear() => IsLastSeasonOfYear(SeasonInYear);

    private static bool IsLastSeasonOfYear(Season s) => _seasonInYearSequence[_seasonInYearSequence.Length-1] == s ? true : false;
    private static bool IsLastRoundOfSeason(int r) => r == _lastRoundInSeason;

    private static Season GetNextSeason(Season s) => IsLastSeasonOfYear(s) ? _seasonInYearSequence[0] : _seasonInYearSequence[GetSeasonIndex(s)+1];
    private static int GetNextRound(int r) => IsLastRoundOfSeason(r) ? _firstRoundInSeason : r+1;


}


