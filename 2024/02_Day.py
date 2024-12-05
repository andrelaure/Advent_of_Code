def read_file():
    with open('02_Input.txt', 'r') as file:
        row = file.readlines()
    return row

def is_safe(level):
    increasing = all(1 <= level[i + 1] - level[i] <= 3 for i in range(len(level) - 1))
    decreasing = all(1 <= level[i] - level[i + 1] <= 3 for i in range(len(level) - 1))
    return increasing or decreasing

def is_safe_p2(level):
    for i in range(len(level)):
        mod_lvl = level[:i] + level[i+1:]
        if is_safe(mod_lvl):
            return True
    return False

#-------------------------------------------------------------------------------
#MAIN

records = read_file()
validRecords = 0
for record in records:
    levels = list(map(int, record.split()))
    if is_safe(levels) or is_safe_p2(levels):
        validRecords += 1
print (validRecords)

#END   
