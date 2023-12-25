using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHPC.World;
using MelonLoader;
using RandomNightBattles;
using UnityEngine;
using GHPC.State;
using System.Collections;

[assembly: MelonInfo(typeof(RandomNightBattlesMod), "Random Night Battles", "1.0.0", "ATLAS")]
[assembly: MelonGame("Radian Simulations LLC", "GHPC")]

namespace RandomNightBattles
{
    public class RandomNightBattlesMod : MelonMod
    {
        MelonPreferences_Category cfg;
        MelonPreferences_Entry<int> chance;

        public override void OnInitializeMelon()
        {
            cfg = MelonPreferences.CreateCategory("RandomNightBattles");
            chance = cfg.CreateEntry<int>("Chance", 25);
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (sceneName == "MainMenu2_Scene" || sceneName == "LOADER_MENU" || sceneName == "LOADER_INITIAL" || sceneName == "t64_menu") return;

            StateController.RunOrDefer(GameState.GameReady, new GameStateEventHandler(ChangeToNight), GameStatePriority.Lowest);
        }

        public IEnumerator ChangeToNight(GameState _) {
            int rand = UnityEngine.Random.Range(1, 100);

            if (rand <= chance.Value)
            {
                GameObject.Find("Sky").GetComponent<CelestialSky>().t = 400;
            }

            yield break;
        }

    }
}
