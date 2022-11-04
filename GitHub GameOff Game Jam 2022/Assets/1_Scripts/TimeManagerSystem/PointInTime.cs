using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Season {    
    Summer, Fall, Winter, Spring
}

public class PointInTime {

    // hardcoded definitions of how time should progress
    private static readonly Season[] _seasonInYearSequence = { Season.Summer, Season.Fall, Season.Winter, Season.Spring };
    private static readonly int[] _monthInSeasonSequence = { 0, 1, 2 };

    PointInTime(int year, Season seasonInYear, int monthInSeason) {
        Year = year;
        SeasonInYear = seasonInYear;
        MonthInSeason = monthInSeason;
    }

    public int Year { get; private set; }
    public Season SeasonInYear { get; private set; }
    public int MonthInSeason { get; private set; }

    public static PointInTime GenerateFirstPointInTime() {
        return new PointInTime(0, _seasonInYearSequence[0], _monthInSeasonSequence[0]);
    }

    public PointInTime GenerateNext() {

        int     newYear;
        Season  newSeason;
        int     newMonth;

        if (IsLastMonthOfSeason() && IsLastSeasonOfYear()) { // if at end of year
            newYear     = Year + 1;
            newSeason   = _seasonInYearSequence[0];
            newMonth    = _monthInSeasonSequence[0];
        } else if (IsLastMonthOfSeason()) { // if at end of season but not end of year
            newYear     = Year;
            newSeason   = _seasonInYearSequence[GetSeasonIndex()+1]; // todo increment
            newMonth    = _monthInSeasonSequence[0];
        } else { // if just within a season
            newYear     = Year;
            newSeason   = SeasonInYear;
            newMonth    = _monthInSeasonSequence[GetMonthIndex()+1]; // todo increment
        }

        return new PointInTime(newYear, newSeason, newMonth);
    }

    private int GetSeasonIndex() => Array.IndexOf(_seasonInYearSequence, SeasonInYear);
    private int GetMonthIndex() => Array.IndexOf(_monthInSeasonSequence, MonthInSeason);

    private bool IsLastMonthOfSeason() => _monthInSeasonSequence[_monthInSeasonSequence.Length-1] == MonthInSeason ? true : false;
    private bool IsLastSeasonOfYear() => _seasonInYearSequence[_seasonInYearSequence.Length-1] == SeasonInYear ? true : false;



}


