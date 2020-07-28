using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiceRollerClicker
{
    public class GameManager
    {
        public DiceBag DiceBag = new DiceBag();
        public int GoblinCount = 0;
        public long Score = 0;
        public readonly Dictionary<string, int> StoreItemCosts = new Dictionary<string, int>();
        public const int DefaultDieCost = 0;

        public GameManager(bool debug = true)
        {
            StoreItemCosts.Add("Goblin", 0);
            StoreItemCosts.Add("NewD4", 5 * DefaultDieCost);
            StoreItemCosts.Add("NewD6", 7 * DefaultDieCost);
            StoreItemCosts.Add("NewD8", 9 * DefaultDieCost);
            StoreItemCosts.Add("NewD10", 11 * DefaultDieCost);
            StoreItemCosts.Add("NewD12", 13 * DefaultDieCost);
            StoreItemCosts.Add("NewD20", 21 * DefaultDieCost);
            DiceBag.Dice[4] = 1;
            doGoblinClicks();

            if (debug)
            {
                BuyD4();
                BuyD6();
                BuyD8();
                BuyD10();
                BuyD12();
                BuyD20();
                BuyGoblin();
                for (int i = 0; i < 50; i++)
                {
                    Click();
                }
            }
        }

        private async void doGoblinClicks()
        {
            do
            {
                int GoblinsYetToClick = GoblinCount;
                for (int i = 0; i < 50; i++)
                {
                    if (GoblinsYetToClick > 0)
                    {
                        int GoblinsToClickThisCheck = GoblinCount / 50;
                        GoblinsToClickThisCheck = GoblinsToClickThisCheck <= GoblinsYetToClick ? GoblinsToClickThisCheck : GoblinsYetToClick;
                        for (int j = 0; j < GoblinsToClickThisCheck; j++)
                        {
                            Click();
                        }
                        GoblinsYetToClick -= GoblinsToClickThisCheck;
                    }
                    await Task.Delay(20);
                }
            } while (true);
        }

        public void Click()
        {
            Score += DiceBag.Roll();
        }

        public void BuyGoblin()
        {
            if (Score >= StoreItemCosts["Goblin"])
            {
                Score -= StoreItemCosts["Goblin"];
                GoblinCount++;
            }
        }

        public void BuyD4()
        {
            if (Score >= StoreItemCosts["NewD4"])
            {
                Score -= StoreItemCosts["NewD4"];
                DiceBag.Dice[4] = DiceBag.Dice[4] + 1;
            }
        }

        public void BuyD6()
        {
            if (Score >= StoreItemCosts["NewD6"])
            {
                Score -= StoreItemCosts["NewD6"];
                DiceBag.Dice[6] = DiceBag.Dice[6] + 1;
            }
        }

        public void BuyD8()
        {
            if (Score >= StoreItemCosts["NewD8"])
            {
                Score -= StoreItemCosts["NewD8"];
                DiceBag.Dice[8] = DiceBag.Dice[8] + 1;
            }
        }

        public void BuyD10()
        {
            if (Score >= StoreItemCosts["NewD10"])
            {
                Score -= StoreItemCosts["NewD10"];
                DiceBag.Dice[10] = DiceBag.Dice[10] + 1;
            }
        }

        public void BuyD12()
        {
            if (Score >= StoreItemCosts["NewD12"])
            {
                Score -= StoreItemCosts["NewD12"];
                DiceBag.Dice[12] = DiceBag.Dice[12] + 1;
            }
        }

        public void BuyD20()
        {
            if (Score >= StoreItemCosts["NewD20"])
            {
                Score -= StoreItemCosts["NewD20"];
                DiceBag.Dice[20] = DiceBag.Dice[20] + 1;
            }
        }
    }
}
