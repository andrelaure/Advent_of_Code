
with open("05_input.txt", "r") as file:
    stacks = []
    while True:
        line = file.readline()
        line = line[:-1]
        if(line == ""):
            break

        if (line.find("[_]")):            
            skip = 0
            for y in line:
                if (y == "[" or y == "]"):
                        continue
                if (y == " "):
                    skip +=1
                    if (skip == 4):
                        stacks.append(".")
                        skip = 0
                
                else:
                    stacks.append(y)
                    skip = 0
    
        lenght = len(stacks)

    print (lenght)

