using UnityEngine;

public class ForStringRounderer
{
    internal string RoundTimeFloat(float input)
    {
        float time = Mathf.Round(input);
        float miuntes = Mathf.Round(time / 60);
        float hours = Mathf.Round(miuntes / 60); // why i've added this..?
        if (hours >= 1)
        {
            return hours + "Hours, " + miuntes % 60 + "Minutes, " + time % 60 + " Seconds";
        }
        else if (miuntes >= 1)
        {
            return miuntes + "Minutes, " + time % 60+" Seconds";
        }
        return time.ToString()+" Seconds";
    }
    internal string RoundScoreFloat(float score)
    {
        if (score >= 1000000)
        {
            return $"{Mathf.Round(score / 100000) / 10} M";
        }
        else if (score >= 1000)
        {
            return $"{Mathf.Round(score / 100) / 10} K";
        }
        return Mathf.Round(score).ToString();
    }
}
