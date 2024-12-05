import re

def read_file():
    with open('03_Input.txt', 'r') as file:
        row = file.readlines()
    return row


def mul_expression(records, mul_pattern):
    mul_exp = []
    numbers = []
    total = 0

    for record in records:
        mul_exp += re.findall(mul_pattern, record)

    num_pattern = r"\d{1,3}"
    for mul in mul_exp:
        numbers += re.findall(num_pattern, mul)
        if len(numbers) == 2 : 
            total += int(numbers[0]) * int(numbers[1])
            numbers.clear()
    
    return total

def mul_do_expression(records, mul_do_pattern):
    mul_exp = []
    numbers = []
    total = 0
    do = True

    #part_1
    #for record in records:
    #    mul_exp += re.findall(mul_do_pattern, record)

    #part_2
    for record in records:
        mul_exp += re.findall(mul_do_pattern)
    
    #solo per part_2
    #mettere una funzione che prenda mul_exp e mantenga solo i numeri che seguono do() o il primo numero incontrato

    num_pattern = r"\d{1,3}"
    for mul in mul_exp:
        numbers += re.findall(num_pattern, mul)
        if len(numbers) == 2 : 
            total += int(numbers[0]) * int(numbers[1])
            numbers.clear()
    
    return total


#-------------------------------------------------------------------------------
#MAIN

records = read_file()
mul_pattern = r"mul\(\d{1,3},\d{1,3}\)"
do_pattern = r"mul\(\d{1,3},\d{1,3}\)|do\(\)|don\'t\(\)"

#part_1
#total = mul_expression(records, mul_pattern)

#part_2
total = mul_do_expression(records, do_pattern)

print (total)

#END   
