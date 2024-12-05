def ReadFile():
    with open('02_Input.txt', 'r') as file:
        row = file.readlines()
    return row

def IsSafe(level):
    increasing = all(1 <= level[i + 1] - level[i] <= 3 for i in range(len(level) - 1))
    decreasing = all(1 <= level[i] - level[i + 1] <= 3 for i in range(len(level) - 1))
    return increasing or decreasing

def IsReallySafe(level):
    for i in range(len(level)):
        mod_lvl = level[:i] + level[i+1:]
        if IsSafe(mod_lvl):
            return True
    return False

#-------------------------------------------------------------------------------
#MAIN

records = ReadFile()
validRecords = 0
for record in records:
    levels = list(map(int, record.split()))
    #if IsSafe(levels):
    if IsReallySafe(levels):
        validRecords += 1
print (validRecords)

#END   
