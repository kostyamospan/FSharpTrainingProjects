open System


let alphabetList = ['a' .. 'z']

let caesarEncrypt (value : string, key : int) : string =
    let charArr = Seq.toArray value

    let getIndexOf (arr: array<char>) (value) : int= 
        let index = Array.IndexOf (arr, value) 
        if index = -1 then Array.IndexOf (arr, (Char.ToLower value)) 
        else index
            
    for i = 0 to value.Length - 1 do
        let isUpper = Char.IsUpper charArr.[i]
        let alpIndex = getIndexOf (Array.ofList alphabetList) ( charArr.[i]) + key |> (fun v ->  if v >= alphabetList.Length then  v - alphabetList.Length  else if v - key = -1 then -1 else v)

        if alpIndex <> -1 then
            charArr.[i] <- if isUpper = true then alphabetList.[alpIndex] |> Char.ToUpper else alphabetList.[alpIndex ]
        else
            charArr.[i] <- charArr.[i]

        
    charArr
    |> System.String

let caesarDecrypt (value: string, key: int) : string  =
    let charArr = Seq.toArray value
    
    let getIndexOf (arr: array<char>) (value) : int= 
        let index = Array.IndexOf (arr, value) 
        if index = -1 then Array.IndexOf (arr, (Char.ToLower value)) 
        else index
                
    for i = 0 to value.Length - 1 do
        let isUpper = Char.IsUpper charArr.[i]

        let alpIndex = getIndexOf (Array.ofList alphabetList) ( charArr.[i]) - key |> (fun v ->  if v < -1 && v >= -key then alphabetList.Length + v else if v + key = -1 then -1 else v)
        
        if alpIndex <> -1 then
            charArr.[i] <- if isUpper = true then alphabetList.[alpIndex] |> Char.ToUpper else alphabetList.[alpIndex]
        else
            charArr.[i] <- charArr.[i]
    
    charArr
    |> System.String

[<EntryPoint>]
let main argv =
    
    let str = "Some string to encode"

    let encodedString = caesarEncrypt(str, 3)

    let decodedString = caesarDecrypt(encodedString, 3)

    Console.WriteLine(encodedString)
    Console.WriteLine(decodedString)
    
    0 // execution code
