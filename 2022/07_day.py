with open ("07_input.txt", "r") as file:

    path = [["root", 0]]
    cur_dir_size = 0

    while True:
        line = file.readline()
        line = line[:-1]
        if line == "":
            break

        line = line.split(" ")
        for val in line:
            if "dir" in line or "ls" in line:
                break
            if val != "$":
                if "cd" in line:
                    if ".." in line:
                        
                        print("come back to the parent, add ", cur_dir_size)
                        
                    else:
                        path.append([line[2], 0])
                        print("create a new son called ", line[2])
                        break
                else:
                    print(path[-1])
                    for val in path[-1]:
                        val[1] += int(line[0])
                    
                    #cur_dir_size += int(line[0])
            #print(line)

    print(path)

file.close()
