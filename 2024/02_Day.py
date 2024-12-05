def read_file():
    with open('02_Input.txt', 'r') as file:
        row = file.readlines()
    return row

def is_safe(report):
    increasing = all(1 <= report[i + 1] - report[i] <= 3 for i in range(len(report) - 1))
    decreasing = all(1 <= report[i] - report[i + 1] <= 3 for i in range(len(report) - 1))
    return increasing or decreasing

def is_safe_p2(report):
    for i in range(len(report)):
        modified_report = report[:i] + report[i+1:]
        if is_safe(modified_report):
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
