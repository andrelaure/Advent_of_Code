with open ("06_input.txt", "r") as file:
    line = file.readline()
    line = line[:-1]
    
    result=""
    times = 0
    for x in line:
        times += 1
        while x in result:
            result = result[1:]
        result += x
        if (len(result) == 4):
            print("numeber of char processed: ", times)
            break

file.close()
