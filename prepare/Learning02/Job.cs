public class Job{
        public string _company; // this is a string that holds the company the person works for 

        public string _jobTitle; // string for job title 

        public int _startYer, _endYear; // int to track the start year and end year of the job

        public void Display(){
            Console.WriteLine($"{_jobTitle} ({_company}) {_startYer}-{_endYear}");
        }
    }