using UnityEngine;



public class Next : NewWords
{
    private NewWords newWords;
    public void NextBut()
    {
        Debug.Log("здесь кьюрент " + currentAsset + " ассет ");
        //Debug.Log("Внутри некст");
        //obj = GameObject.FindGameObjectsWithTag("DeleteWordObject");
        Destroy(currentAsset);
        pronsance.GetComponent<AudioSource>().Stop();
        if (oneFromList.Count > 0)
        {
            Debug.Log("Внутри условия");
            //GetComponent<MeshFilter>().mesh = wordGenerate.ObjOfWord.GetComponent<MeshFilter>().mesh;
            oneFromList.Remove(wordGenerate);
            Debug.Log("Not Generation");
            Generate();
            Debug.Log("Generation");
            Debug.Log("Вне условия");
        }
        else
        {
            Debug.Log("Нет Элементов в списке ");
            learningBlock.SetActive(false);
            endPanel.SetActive(true);
            Debug.Log("Нет Элементов в списке ");
        }

    }
}

