function linq(massiv) {

    var linqArray = [];
    ///<summary>Обертка для выполнения LINQ-операций над массивом</summary>
    ///<param name ="massiv" type="Array">Любой массив</param>

    linqArray.distinct = function() {
        ///<summary>Удаляет в массиве одинаковые записи</summary>
    };

    linqArray.count = function (predicate) {
        ///<summary>Возвращает количество элементов в массиве согласно введенному предикату</summary>
        ///<param name="predicate" type="string">Предикат или условие, по которому фильтруются значения.</param>
    };

    linqArray.where = function (predicate) {
        ///<summary>Фильтрует массив по значениям заданным в предикате</summary>
        ///<param name="predicate" type="string">Предикат или условие, по которому фильтруются значения.</param>
    };

    linqArray.select = function (predicate) {
        ///<summary>Выбор значений заданных в преикате</summary>
        ///<param name="predicate" type="string">Предикат или условие, по которому фильтруются значения.</param>
    };

    linqArray.selectRange = function (rangeArray, predicate) {
        
    };

    linqArray.first = function (predicate) {
        ///<summary>Возвращает первый элемент в массиве, удовлетворяющий условию в предикате. По умолчанию возвращает первый элемент.</summary>
        ///<param name="predicate" type="string">Предикат или условие, по которому фильтруются значения.</param>
    };

    linqArray.any = function (predicate) {
        ///<summary>Возвращает истину, если хотя бы оин элемент удовлетворяет условию предиката. По умолчанию возвращает истину, если в массиве есть хотя бы оин элемент.</summary>
        ///<param name="predicate" type="string">Предикат или условие, по которому фильтруются значения.</param>
    };

    linqArray.sum = function (predicate) {
        ///<summary>Возвращает сумму элементов по условию, которое заданно в предикате.</summary>
        ///<param name="predicate" type="string">Предикат или условие, по которому фильтруются значения.</param>
    };

    return linqArray;
}