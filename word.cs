namespace Jumper
{

  class Word
  {
    public string getRandomWord()
    {
      Random random = new Random();
      List<string> wordDictionary = new List<string> {"halloween", "witch", "ghost", "pumpkin", "mummy", "vampire", "scary", "boo", "bat", "candy"};
      int index = random.Next(wordDictionary.Count);
      String randomWord = wordDictionary[index];
      return randomWord;
    }
    
  }
}   
  
