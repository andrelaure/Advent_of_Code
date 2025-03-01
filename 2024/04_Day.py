def ReadFile():
    with open('04_Input.txt', 'r') as file:
        row = file.readlines()
    return row

def ScanXmas(sample):
    count = 0
    for i, elem in enumerate(sample):
        for j, ch in enumerate(elem):
            #part_1
            #if ch == 'X' : count += FindXmas(sample, i, j)
            
            #part_2
            #if ch == 'A' : count += CheckXPattern(sample, i, j)
            if ch == 'A': 
                if CheckXPattern(sample, i, j):
                    count += 1
    return count


#part_1
def FindXmas(sample, i, j):
    count = 0
    directions = [(-1, -1),(-1, 0),(-1, 1),  
                  (0, -1),         (0, 1),   
                  (1, -1), (1, 0), (1, 1)]  
    
    for dx, dy in directions:
        if CheckXmas(sample, i, j, dx, dy, "XMAS") : count += 1
    return False

def CheckXmas(sample, i, j, dx, dy, xmas):
    for k, char in enumerate(xmas):
        ni, nj = i + k * dx, j + k * dy
        if not IsValid(sample, ni, nj) or sample[ni][nj] != char : return False
    return True

def IsValid(sample, i, j):
    return 0 <= i < len(sample) and 0 <= j < len(sample[i])


#-------------------------------


#part_2
def CheckXPattern(sample, i, j):
    diagonals = [
        [(-1, -1, 'M'), (1, 1, 'S')],
        [(-1, 1, 'M'), (1, -1, 'S')],
        [(-1, -1, 'S'), (1, 1, 'M')],
        [(-1, 1, 'S'), (1, -1, 'M')]
    ]
    
    for diag in diagonals:
        if CheckDiagonal(sample, i, j, diag):
            return 1
    return 0

def CheckDiagonal(sample, i, j, diagonal):
    for dx, dy, char in diagonal:  
        ni, nj = i + dx, j + dy
        if char == 'M':
            if not IsValid(sample, ni, nj) or sample[ni][nj] != 'S' : return False
    
        elif char == 'S':
            if not IsValid(sample, ni, nj) or sample[ni][nj] != 'M' : return False
        
    return True

#-------------------------------------------------------------------------------
#MAIN

records = ReadFile()
sample = ["MMMSXXMASM",
          "MSAMXMSMSA",
          "AMXSXMAAMM",
          "MSAMASMSMX",
          "XMASAMXAMM",
          "XXAMMXXAMA",
          "SMSMSASXSS",
          "SAXAMASAAA",
          "MAMMMXMMMM",
          "MXMXAXMASX"]

xmas_counter = ScanXmas(sample)   
    

print ("xmas_counter: ", xmas_counter)
#END 
