using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawner : MonoBehaviour
{
    public GameObject PipePrefab; // ссылка на объект, который будет спавнитс€. ЅерЄм из папки префабов 
    public float MaxYBorder; // максимальна€ верхн€€ граница спавна труб
    public float MinYBorder; // минимальна€ нижн€€ граница спавна труб

    private void Start()
    {
        float startSpawnTime = 0f; // врем€, через которое начнЄтс€ выполнение метода SpawnPipes
        float repeatSpawnTime = 2f; // врем€, через которое будет повотор€тьс€ выполнение метода SpawnPipes
        InvokeRepeating(nameof(SpawnPipes), startSpawnTime, repeatSpawnTime); // метод, который вызывает метод(SpawnPipes) через определЄнное врем€ после старта игры и повтор€ет вызов (выполнение) через указанный промежуток времени

    }
    private void SpawnPipes()// метод, который спавнит трубы 
    {
        GameObject pipe = Instantiate(PipePrefab, transform.position, Quaternion.identity); // через функцию Instantiate берЄтс€ ссылка на объект труб (PipePrefab)б делает его по€вление в позиции конкретно спавнера и в нулевом повороте (то есть он всегда находитс€ в нормальном дл€ пользовател€ положении)
        pipe.transform.position = new Vector2(transform.position.x, Random.Range(MinYBorder, MaxYBorder)); // обращаемс€ к экземпл€ру труб (объект, который получилс€ при копировании с основного! (оригинала)) и устанавливаем ему позиции с учетом разброса по высоте

    }

}
