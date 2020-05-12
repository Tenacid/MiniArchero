using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Hero heroAsset;

    [SerializeField]
    private Coin coinAsset;

    private Hero heroInstance;
    private List<Enemy> enemies = new List<Enemy>();
    private Dictionary<GameObject, Enemy> enemiesDict = new Dictionary<GameObject, Enemy>();
    private List<Bullet> unusedBullets = new List<Bullet>();
    private List<Coin> unusedCoins = new List<Coin>();


    private int coins = 0;
    private static Game instance;



    public static Game getInstance() {
        if (instance == null) {
            instance = FindObjectOfType<Game>();
        }

        return instance;
    }

    private void Start() {
        InterfaceManager.getInstance().redrawCoinsCount(coins);
    }

    public void collectCoin() {
        coins++;
        InterfaceManager.getInstance().redrawCoinsCount(coins);
    }

    public void addEnemy(Enemy newEnemy) {
        enemies.Add(newEnemy);

        enemiesDict.Add(newEnemy.gameObject, newEnemy);
    }

    public Enemy getEnemyByGO(GameObject enemyGO) {
        Enemy retVal = null;

        if (enemiesDict.ContainsKey(enemyGO)) {
            retVal = enemiesDict[enemyGO];
        }

        return retVal;
    }

    public void removeEnemy(Enemy enemy) {
        enemies.Remove(enemy);
        enemiesDict.Remove(enemy.gameObject);

        heroInstance.resetFocusedEnemy();

        enemy.transform.position = Constants.hiddenPos;


    }

    public Enemy getNearestEnemy(Vector3 fromPoint) {
        float minDistance = float.MaxValue;
        Enemy retVal = null;

        foreach (Enemy enemy in enemies) {
            if (Vector3.Distance(fromPoint, enemy.transform.position) < minDistance) {
                minDistance = Vector3.Distance(fromPoint, enemy.transform.position);
                retVal = enemy;
            }
        }

        return retVal;
    }

    public Hero getHero() {
        return heroInstance;
    }

    public void instaniateHero(Vector3 point) {
        heroInstance = Instantiate(heroAsset);
        heroInstance.transform.position = point;
    }

    public void addUnusedBullet(Bullet bullet) {

        bullet.getCollider().enabled = false;
        bullet.transform.position = Constants.hiddenPos;

        bullet.getRigidbody().velocity = Vector3.zero;

        unusedBullets.Add(bullet);
    }

    public Bullet getBullet(Bullet bulletAsset) {
        Bullet retVal = null;

        if (unusedBullets.Count > 0) {
            retVal = unusedBullets[unusedBullets.Count - 1];
            unusedBullets.RemoveAt(unusedBullets.Count - 1);
        } else {
            retVal = Instantiate(bulletAsset);
            retVal.transform.position = Constants.hiddenPos;
        }

        retVal.getCollider().enabled = true;

        return retVal;
    }

    public void addUnusedCoin(Coin coin) {
        coin.getCollider().enabled = false;
        coin.transform.position = Constants.hiddenPos;
        
        unusedCoins.Add(coin);
    }

    public bool isHero(GameObject go) {
        return heroInstance.gameObject == go;
    }

    public Coin getCoin() {
        Coin retVal = null;

        if (unusedCoins.Count > 0) {
            retVal = unusedCoins[unusedCoins.Count - 1];
            unusedCoins.RemoveAt(unusedCoins.Count - 1);
        } else {
            retVal = Instantiate(coinAsset);
            retVal.transform.position = Constants.hiddenPos;
        }

        retVal.getCollider().enabled = true;

        return retVal;
    }

}
