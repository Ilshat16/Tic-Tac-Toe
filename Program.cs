bool CheckPosition(string positionCheck, int num)
{
    bool flag = true;
    for (int i = 0; i < positionCheck.Length; i++)
    {
        int chekNum = positionCheck[i] - '0';
        if (num == chekNum)
        {
            flag = false;
            break;
        }
    }
    return flag;
}

int CompRunning(int num, string positionCheck, string remainingNums)
{
    bool flag = false;
    while (flag == false)
    {
        int numInd = new Random().Next(0, remainingNums.Length - 1);
        num = remainingNums[numInd] - '0';
        flag = CheckPosition(positionCheck, num);
    }
    return num;
}

int SelectNum(int gameVersion, int num, string positionCheck)
{
    bool flag = false;
    while (flag == false)
    {
        num = EnterData("Введите номер поля: ");
        flag = CheckPosition(positionCheck, num);
        if (flag == false) System.Console.WriteLine("Это поле занято, введите другое число");
    }
    return num;
}

int GameCheck(int[,] positionMatrix, int flag)
{
    if (positionMatrix[0, 0] == positionMatrix[0, 1] &&
        positionMatrix[0, 0] == positionMatrix[0, 2] && positionMatrix[0, 0] != 0) flag = positionMatrix[0, 0];
    if (positionMatrix[1, 0] == positionMatrix[1, 1] &&
        positionMatrix[1, 0] == positionMatrix[1, 2] && positionMatrix[1, 0] != 0) flag = positionMatrix[1, 0];
    if (positionMatrix[2, 0] == positionMatrix[2, 1] &&
        positionMatrix[2, 0] == positionMatrix[2, 2] && positionMatrix[2, 0] != 0) flag = positionMatrix[2, 0];
    if (positionMatrix[0, 0] == positionMatrix[1, 0] &&
        positionMatrix[0, 0] == positionMatrix[2, 0] && positionMatrix[0, 0] != 0) flag = positionMatrix[0, 0];
    if (positionMatrix[0, 1] == positionMatrix[1, 1] &&
        positionMatrix[0, 1] == positionMatrix[2, 1] && positionMatrix[0, 1] != 0) flag = positionMatrix[0, 1];
    if (positionMatrix[0, 2] == positionMatrix[1, 2] &&
        positionMatrix[0, 2] == positionMatrix[2, 2] && positionMatrix[0, 2] != 0) flag = positionMatrix[0, 2];
    if (positionMatrix[0, 0] == positionMatrix[1, 1] &&
        positionMatrix[0, 0] == positionMatrix[2, 2] && positionMatrix[0, 0] != 0) flag = positionMatrix[0, 0];
    if (positionMatrix[2, 0] == positionMatrix[1, 1] &&
        positionMatrix[2, 0] == positionMatrix[0, 2] && positionMatrix[2, 0] != 0) flag = positionMatrix[2, 0];
    return flag;
}

void FindArea(int[] areaCoords, int[,] positionMatrix, int figure, int num, int borderLength)
{
    if (num == 1)
    {
        areaCoords[0] = borderLength / 6;
        areaCoords[1] = borderLength / 6;
        positionMatrix[0, 0] = figure;
    }
    if (num == 2)
    {
        areaCoords[0] = borderLength / 6;
        areaCoords[1] = borderLength / 2;
        positionMatrix[0, 1] = figure;
    }
    if (num == 3)
    {
        areaCoords[0] = borderLength / 6;
        areaCoords[1] = borderLength - 1 - borderLength / 6;
        positionMatrix[0, 2] = figure;
    }
    if (num == 4)
    {
        areaCoords[0] = borderLength / 2;
        areaCoords[1] = borderLength / 6;
        positionMatrix[1, 0] = figure;
    }
    if (num == 5)
    {
        areaCoords[0] = borderLength / 2;
        areaCoords[1] = borderLength / 2;
        positionMatrix[1, 1] = figure;
    }
    if (num == 6)
    {
        areaCoords[0] = borderLength / 2;
        areaCoords[1] = borderLength - 1 - borderLength / 6;
        positionMatrix[1, 2] = figure;
    }
    if (num == 7)
    {
        areaCoords[0] = borderLength - 1 - borderLength / 6;
        areaCoords[1] = borderLength / 6;
        positionMatrix[2, 0] = figure;
    }
    if (num == 8)
    {
        areaCoords[0] = borderLength - 1 - borderLength / 6;
        areaCoords[1] = borderLength / 2;
        positionMatrix[2, 1] = figure;
    }
    if (num == 9)
    {
        areaCoords[0] = borderLength - 1 - borderLength / 6;
        areaCoords[1] = borderLength - 1 - borderLength / 6;
        positionMatrix[2, 2] = figure;
    }
}

void CreateCross(int[,] matrix, int width, int[] areaCoords)
{
    int rowCoord = areaCoords[0];
    int colCoord = areaCoords[1];
    for (int i = -width / 2; i <= width / 2; i++)
    {
        matrix[i + rowCoord, i + colCoord] = 1;
        matrix[i + rowCoord, -i + colCoord] = 1;
    }
}

void CreateSquare(int[,] matrix, int width, int[] areaCoords)
{
    int rowCoord = areaCoords[0];
    int colCoord = areaCoords[1];
    for (int i = -width / 2; i <= width / 2; i++)
    {
        matrix[rowCoord - width / 2, i + colCoord] = 1;
        matrix[rowCoord + width / 2, i + colCoord] = 1;
        matrix[rowCoord + i, colCoord - width / 2] = 1;
        matrix[rowCoord + i, colCoord + width / 2] = 1;
    }
}

int[,] CreateGrid(int borderLength)
{
    int[,] matrix = new int[borderLength, borderLength];
    for (int i = 0; i < borderLength; i++)
    {
        for (int j = 0; j < borderLength; j++)
        {
            if (i == borderLength / 3 || i == borderLength * 2 / 3 ||
                j == borderLength / 3 || j == borderLength * 2 / 3) matrix[i, j] = 1;
            else matrix[i, j] = 0;
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix, int borderLength)
{
    Console.Clear();
    for (int i = 0; i < borderLength; i++)
    {
        for (int j = 0; j < borderLength; j++)
        {
            if (matrix[i, j] == 0) Console.Write("  ");
            else Console.Write("+ ");
        }
        Console.WriteLine();
    }
}

int EnterData(string text)
{
    Console.Write(text);
    int number = int.Parse(Console.ReadLine());
    return number;
}

int borderLength = 20;
int width = borderLength / 3 - 2;
int[,] matrix = CreateGrid(borderLength);
int[,] positionMatrix = new int[3, 3];
int[] areaCoords = new int[2];
PrintMatrix(matrix, borderLength);
System.Console.WriteLine("Выберите вариант игры:");
System.Console.WriteLine("1 - игрок против игрока");
System.Console.WriteLine("2 - игрок против компьютера");
int gameVersion = EnterData("Введите соотевтствующее число: ");
int playerFigure = 1;
if (gameVersion == 2) playerFigure = EnterData("Какой фигурой хотите играть? Введите 1 если крестик, 2 нолик: ");
int num = 1;
int winningFigure = 0;
int count = 0;
int figure = 1;
string positionCheck = "";
string remainingNums = Convert.ToString(123456789);
while (num != 0)
{
    count += 1;
    if (count % 2 == 0)
    {
        figure = 2;
        System.Console.WriteLine("Ход нолика");
        if (gameVersion == 2 && playerFigure == 1) num = CompRunning(num, positionCheck, remainingNums);
        else num = SelectNum(gameVersion, num, positionCheck);

    }
    else
    {
        figure = 1;
        System.Console.WriteLine("Ход крестика");
        if (gameVersion == 2 && playerFigure == 2) num = CompRunning(num, positionCheck, remainingNums);
        else num = SelectNum(gameVersion, num, positionCheck);
    }
    remainingNums = string.Join("", remainingNums.Split(num.ToString()));
    positionCheck += num.ToString();
    if (num == 0) break;
    FindArea(areaCoords, positionMatrix, figure, num, borderLength);
    if (figure == 1) CreateCross(matrix, width, areaCoords);
    else CreateSquare(matrix, width, areaCoords);
    winningFigure = GameCheck(positionMatrix, winningFigure);
    PrintMatrix(matrix, borderLength);
    if (winningFigure == 1)
    {
        System.Console.WriteLine("Выиграл крестик");
        break;
    }
    if (winningFigure == 2)
    {
        System.Console.WriteLine("Выиграл нолик");
        break;
    }
    if (count == 9)
    {
        System.Console.WriteLine("Ничья");
        break;
    }
}