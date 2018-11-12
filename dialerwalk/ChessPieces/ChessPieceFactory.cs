using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

public static class ChessPieceFactory
{
    private static Dictionary<string,ChessPiece> PiecesRepository;
    static ChessPieceFactory(){
        Assembly assembly = Assembly.GetCallingAssembly();

        //Example of LINQ:
        var chessPieces = from type in assembly.GetTypes()
                where type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(ChessPiece))
                select (ChessPiece) Activator.CreateInstance(type);  
        PiecesRepository = chessPieces.ToDictionary(c=>c.Name.ToUpper(),c=>c);
   
    }
    public static ChessPiece GetChessPieceByName(string name)
    {
        if(string.IsNullOrEmpty(name))
            throw new KeyNotFoundException($"Piece name was not provided");          

        if(PiecesRepository.TryGetValue(name.ToUpper(), out ChessPiece piece)){
            return piece;
        }
        throw new KeyNotFoundException($"Did not find piece with name: {name}");          
    }

    
}