
def read_file():
    with open('02_Input.txt', 'r') as file:
        row = file.readlines()
    return row

#part_1
def is_safe(record):
    levels = list(map(int, record.split()))
    maj = -1
    for i in range(1, len(levels)):
        if abs(levels[i] - levels[i - 1]) > 3 or abs(levels[i] - levels[i - 1]) == 0 : return False   
        if maj == -1 :
            if levels[i] > levels[i - 1] : maj = 0
            if levels[i] < levels[i - 1] : maj = 1
        else : 
            if levels[i] > levels[i - 1] and (maj==1) : return False
            if levels[i] < levels[i - 1] and (maj==0) : return False  
        
    return True

#part_2
def is_safe2(record):
    levels = list(map(int, record.split()))
    maj = -1
    skip_lvl = False
    for i in range(1, len(levels)):
        if  skip_lvl == False:
            if abs(levels[i] - levels[i - 1]) > 3 or abs(levels[i] - levels[i - 1]) == 0 : return False   
            if maj == -1 :
                if levels[i] > levels[i - 1] : maj = 0
                if levels[i] < levels[i - 1] : maj = 1
            else:
                if levels[i] > levels[i - 1] and (maj==1) : skip_lvl = True
                if levels[i] < levels[i - 1] and (maj==0) : skip_lvl = True
#       skip_lvl = True
        else:
            if abs(levels[i] - levels[i - 2]) > 3 or abs(levels[i] - levels[i - 2]) == 0 : return False   
            if maj == -1 :
                if levels[i] > levels[i - 2] : maj = 0
                if levels[i] < levels[i - 2] : maj = 1
            else:
                if levels[i] > levels[i - 2] and (maj==1) : skip_lvl = True
                if levels[i] < levels[i - 2] and (maj==0) : skip_lvl = True
        
    return True
#---------------------------------------------------------

#MAIN

records = read_file()
validRecords = 0

for record in records:
#   if is_safe(record):
#       validRecords += 1
    if is_safe2(record):
        validRecords += 1

print(validRecords)

#END   
 