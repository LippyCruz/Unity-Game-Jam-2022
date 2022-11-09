namespace TimeManagement
{
    using TMPro;
    using UnityEngine;

    /// <summary>
    /// Responsible for changing the time panel depending on the updated point in time
    /// </summary>
    /// <author>Ben + Gino</author>
    public class TimePanel : ComputerPhaseStep
    {
        [SerializeField] private TMP_Text yearText;
        [SerializeField] private TMP_Text currentSeasonText;
        [SerializeField] private TMP_Text footerText;
        [SerializeField] private Animator sliderAnimator;

        protected override object[] CheckForMissingReferences() => new object[] 
        {
            yearText, currentSeasonText, footerText, sliderAnimator
        };

        private void UpdateUIElementsForNewTime(PointInTime time)
        {
            yearText.text = $"Year {time.Year}";
            currentSeasonText.text = time.SeasonInYear.ToString();

            string nextSeason = time.GetNextSeason().ToString().ToLower();
            string nextSeasonFormatted = nextSeason[0].ToString().ToUpper() + nextSeason.Substring(1);
            int remainingRounds = time.GetRoundsRemainingInSeason() + 1;
            footerText.text = 
                $"{remainingRounds} turn{(remainingRounds > 1 ? "s" : "")} until {nextSeasonFormatted}";

            if (!time.IsStartingPointInTime())
            {
                sliderAnimator.SetTrigger("Next");
            }
        }

        public override void DoProcessingForComputerPhaseDuringGameInit()
        {
            UpdateUIElementsForNewTime(TimeManager.Instance.CurrentTime);
        }

        public override void DoProcessingForComputerPhase()
        {
            UpdateUIElementsForNewTime(TimeManager.Instance.CurrentTime);
        }
    }
}
