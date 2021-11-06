using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NUnit.Framework;
namespace c_
{
    [TestFixture]
    class Program
    {
        static void Main(string[] args){}

        [Test]
        public void Verify_GetIntegersFromList_equal(){
            var list1234 = new List<int>(){1,2,3,4};
            var expected_list1234 = GetIntegersFromList(new List<object>(){1,"144",2,3,4,"2","14"});
            Assert.AreEqual(list1234,expected_list1234,
                        message:"Expected {1,2,3,4}, got {" + String.Join(", ", expected_list1234) +"}" );
        }
        [Test]
        public void Verify_GetIntegersFromList_not_equal(){
            var list = new List<int>(){1,2,3,4,2};
            Assert.AreNotEqual(list,GetIntegersFromList(new List<object>(){1,"144",2,3,4,"2","14"}));

            list = new List<int>(){1,2,3,4};
            Assert.AreNotEqual(list,GetIntegersFromList(new List<object>(){1,"144",2,3,4,"2","14",4}));
        }

        [Test]
        public void Verify_GetIntegersFromList_not_equal_wrong_input(){
            var list = new List<int>(){1,2,3,4};
            Assert.AreNotEqual(list,GetIntegersFromList(new List<object>()));
            
            list = new List<int>();
            Assert.AreNotEqual(list,GetIntegersFromList(new List<object>(){1,"144",2,3,4,"2","14",4}));
        }

        [Test]
        public void Verify_first_non_repeating_letter_equal(){
            char expected_letter = 't';
            Assert.AreEqual(expected_letter,first_non_repeating_letter("StReSs"));

            expected_letter = 'R';
            Assert.AreEqual(expected_letter,first_non_repeating_letter("StRetSs"));

            expected_letter = '\0';
            Assert.AreEqual(expected_letter,first_non_repeating_letter(""));
    
        }
        
        [Test]
        public void Verify_first_non_repeating_letter_not_equal(){
            char expected_letter = 's';
            Assert.AreNotEqual(expected_letter,first_non_repeating_letter("StRess"));

            expected_letter = 'R';
            Assert.AreNotEqual(expected_letter,first_non_repeating_letter("Rabasr"));

    
        }
       
        [Test]        
        public void Verify_num_of_pairs_equal(){
            var expected = 2;
            Assert.AreEqual(expected,num_of_pairs(new List<int>(){1,2,3,2},3));

            expected = 0;
            Assert.AreEqual(expected,num_of_pairs(new List<int>(){1,2,3,2,3,4,1},1));
        } 
        [Test]        
        public void Verify_num_of_pairs_not_equal(){
            var expected = 2;
            Assert.AreNotEqual(expected,num_of_pairs(new List<int>(){1,2,3,2},2));

            expected = 4;
            Assert.AreNotEqual(expected,num_of_pairs(new List<int>(){1,2,3,2,3,4,1},1));
        } 
        [Test]
        public void Verify_digital_root_equal(){
            var expected = 1+2+4;
            Assert.AreEqual(expected,digital_root(124));


            expected = 8;
            Assert.AreEqual(expected,digital_root(243125));

        }

        [Test]
        public void Verify_digital_root_not_equal(){
            var expected = 1+2+4;
            Assert.AreNotEqual(expected,digital_root(125));


            expected = 0;
            Assert.AreNotEqual(expected,digital_root(243125));
        }

        [Test]
        public void Veirify_sort_guests_equal(){
            string expected = "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";
            string actual =  sort_guests("Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill");
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Veirify_sort_guests_not_equal(){
            string notexpected = "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)(ANDRUSHKO, NAZAR)";
            string actual =  sort_guests("Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill,Andrushko:Nazar");
            Assert.AreNotEqual(notexpected,actual);

        }

        [Test]
        public void Verify_rearranging_equal()
        {
            int expected = 987654321;
            Assert.AreEqual(expected,rearranging(123654789));
        }

        [Test]
         public void Verify_rearranging_equal1()
        {
            int expected = -1;
            Assert.AreEqual(expected,rearranging(321));
        }

    
        [Test]
         public void Verify_ip_from_number_equal()
        {
            string expected = "128.32.10.1";
            Assert.AreEqual(expected,ip_from_number(2149583361));

        }
        [Test]
         public void Verify_ip_from_number_equal1()
        {
            string expected = "0.0.0.0";
            Assert.AreEqual(expected,ip_from_number(0));
        }

 


    // Task1
    public static List<int> GetIntegersFromList(List<object> l1) 
        {
          List<int> newlist = new List<int>();
          foreach(object i in l1) {
            if (i.GetType() == typeof(int)) {
              newlist.Add(Convert.ToInt32(i));
            }
          }
          return newlist;
        }
    // Task2
    static char first_non_repeating_letter(string input_string){
            var input_string_lower = input_string.ToLower();
            Dictionary<char,int> char_to_num_of_inceptions = new Dictionary<char, int>();
            foreach(char elem in input_string_lower){
                if (char_to_num_of_inceptions.ContainsKey(elem))
                    char_to_num_of_inceptions[elem] += 1;
                else
                    char_to_num_of_inceptions.Add(elem,1);

            } 
            for (int i = 0; i < input_string.Length; i++){
                if (char_to_num_of_inceptions[input_string_lower[i]]==1){
                    return input_string[i];
                }
                
            }
            return '\0';
        }
    //Task3
    public static int digital_root(int num) {
      string n1 = Convert.ToString(num);
      int sum = 0;
      while (num != 0) {
          sum += num % 10;
          num /= 10;
      }
      
      if (sum > 9) {
        sum = digital_root(sum);
      }
      return sum;
    }

    // Task4
    public static int num_of_pairs(List<int> nums, int target) {
      int counter = 0;
      for(int i = 0; i < nums.Count; i++) {
        for(int j = i+1; j < nums.Count; j++) {
          if(nums[i] + nums[j] == target) {
            counter += 1;
          }
        }
      }
      return counter;
    }   

    //Task5
    static string sort_guests(string input_string){
            var names_surnames = find_all_names_surnames(input_string);
            var names = names_surnames.Item1;
            var surnames = names_surnames.Item2;
            // Sort by surnames
            for (int i = 0; i < names.Count; i++){
                for (int j = i+1; j < names.Count; j++){
                    if (check_swap(surnames[i],surnames[j])){
                        var temp = surnames[i];
                        surnames[i] = surnames[j];
                        surnames[j] = temp;

                        temp = names[i];
                        names[i] = names[j];
                        names[j] = temp;   
                    }
                }
            }
       
            List<Tuple<int,int>> index_of_same_surnames = new List<Tuple<int, int>>();
            int z = 0;
            for (int i = 1; i < names.Count; i++){
                if(surnames[i] != surnames[i-1]){
                    index_of_same_surnames.Add(new Tuple<int,int>(z,i));
                    z = i;
                }
            }
            //Sort names in groups with same surname
            index_of_same_surnames.Add(new Tuple<int,int>(z,names.Count));
            foreach(Tuple<int,int> idx in index_of_same_surnames){
                for (int i = idx.Item1; i < idx.Item2; i++){
                    for (int j = i+1; j < idx.Item2; j++){
                        if (check_swap(names[i],names[j])){
                            var temp = names[i];
                            names[i] = names[j];
                            names[j] = temp;   
                        }
                    }
                }
            }
     
            string res = "";
            for (int i = 0; i < names.Count; i++){
                res += "(" + surnames[i] + ", " + names[i] + ")";
            }
     
            return res;
        }

    //Task5 helper function
    static Tuple<List<string>,List<string>> find_all_names_surnames(string input_string){
            Regex rg_name = new Regex(@"[A-Z]+:");
            Regex rg_surname = new Regex(@":[A-Z]+");
            List<string> names = new List<string>();
            List<string> surnames = new List<string>();
            foreach (Match match in rg_name.Matches(input_string.ToUpper())){
                names.Add(match.Value.Remove(match.Value.Length-1));
            }
            foreach (Match match in rg_surname.Matches(input_string.ToUpper())){
                surnames.Add(match.Value.Remove(0,1));
            }

            Tuple<List<string>,List<string>> res = new Tuple<List<string>,List<string>>(names,surnames);
            return res;
        }
    static bool check_swap(string lhs, string rhs)
        {
            int min_length = lhs.Length - rhs.Length;
            bool right_is_shorter = false;
            if (min_length < 0){
                right_is_shorter = true;
                min_length *= -1;
            }
            for (int i = 0; i < min_length; i++){
                if ((int)lhs[i] < (int)rhs[i]){
                    return false;
                }
                if ((int)lhs[i] > (int)rhs[i]){
                    return true;            
                }
            }

            return right_is_shorter;
        }

    //Extra Tasks
    static int rearranging(int value){

        int constvalue = value;
        List<int> digits = new List<int>();
        while (value >0)
        {
            digits.Add(value%10);
            value = value/10;
        } 
        digits.Sort((a, b) => b.CompareTo(a));
        var res = Int32.Parse(String.Join("",digits));
        if (res > constvalue)
            return res;

        return -1;
    }


    
    //Helper functions for Task 7
    public static string conv_to_binary(uint num) 
    {
      string bin_num = "";
      var new_num = num;
      while(new_num != 1) {
        var rem = new_num % 2;
        new_num = new_num/2;
        bin_num = rem.ToString() + bin_num;
      }
      bin_num = "1"+bin_num;
      return bin_num;
    } 

    public static string conv_to_dec(string num) {
      char[] arr = num.ToCharArray();
      Array.Reverse(arr);
      string new_num = new string(arr);
      int counter = 1;
      int res = 0;
      foreach(char i in new_num){
        if(i == '1') {
          res += counter;
        }
        counter *= 2;
      }
    return res.ToString();
    }


    //Task 7
    public static string ip_from_number(uint num)
    {
        string binary = conv_to_binary(num);
        string answer = "";
        binary = new string('0', binary.Length % 32) + binary;
        for (int i = 0; i < 32; i++)
        {
            if (i%8 == 0)
                answer += conv_to_dec(binary.Substring(i,8)) + ".";
        }
        return answer.Substring(0,answer.Length-1);
    }
    }
}
