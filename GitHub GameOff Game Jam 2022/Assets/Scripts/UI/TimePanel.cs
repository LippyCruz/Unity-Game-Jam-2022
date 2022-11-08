namespace TimeManagement
{
    using TMPro;
    using UnityEngine.Assertions;

    public class TimePanel : ComputerPhaseStep
    {
        public TextMeshProUGUI footerText;

        private void Awake()
        {
            Assert.IsNotNull(footerText);
        }

        private void UpdateUIElementsForNewTime(PointInTime time)
        {
            footerText.text = $"Month {time.RoundInSeason} of {time.SeasonInYear}, year {time.Year}.\n" +
                $"{time.GetRoundsRemainingInSeason()} months until {time.GetNextSeason()}";
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
