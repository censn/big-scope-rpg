using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneUtil {
    private static readonly HashSet<Scene> SCENES_WITH_PARAMS = new HashSet<Scene>() {

    };

    public static void LoadScene(Scene scene) {
        Util.Assert(!SCENES_WITH_PARAMS.Contains(scene), "{0} requires special parameters to be loaded.", scene);
        ForceLoadScene(scene);
    }

    private static void ForceLoadScene(Scene scene) {
        SceneManager.LoadScene((int)scene);
    }
}

