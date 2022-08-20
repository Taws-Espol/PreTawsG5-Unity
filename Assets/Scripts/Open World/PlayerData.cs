[System.Serializable]
public class PlayerData
{
    public float[] position = new float[3];

    public PlayerData(TopDownCharacterController player){
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
