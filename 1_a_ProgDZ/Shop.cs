using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;
    public TurretBlueprint superTower;
    public TurretBlueprint slowTower;

    BuildManager buildManager;

    void Start ()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret ()
    {
        Debug.Log("standard turet selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("missile launcher selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("laser beamer selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }

    public void SelectsuperTower()
    {
        Debug.Log("big Missile Launcher selected");
        buildManager.SelectTurretToBuild(superTower);
    }

    public void SelectslowTower()
    {
        Debug.Log("big Missile Launcher selected");
        buildManager.SelectTurretToBuild(slowTower);
    }



}
