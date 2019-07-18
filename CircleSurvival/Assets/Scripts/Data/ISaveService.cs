using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveService {
    SaveData Load();
    void Save(SaveData save);
}
