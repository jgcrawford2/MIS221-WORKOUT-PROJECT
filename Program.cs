// Jay Crawford
// Workout Manager Software
// MIS 221 Bonus Project
// (1)Bonus Note: Thanks for everything this semester, this project really pushed me,
// (2)Bonus Note: I was very sick for the last week, so I wasn't able to make everything the way I wanted to. Happy with the result.
// No GUI which was the original goal but glad I got to write a program that combined what we learned + advanced steps + API all into one! :)



using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
// Most of these are just used for the API calls and HTTP handling (:
class Program
{
    static void Main()
    {
        // Display ASCII art
        Console.WriteLine(@" _    _      _                            _          _   _                          
| |  | |    | |                          | |        | | | |                         
| |  | | ___| | ___ ___  _ __ ___   ___  | |_ ___   | |_| |__   ___                 
| |/\| |/ _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \  | __| '_ \ / _ \                
\  /\  /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |_| | | |  __/                
 \/  \/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/   \__|_| |_|\___|                
                                                                                    
                                                                                    
 _    _            _               _    ___  ___                                  _ 
| |  | |          | |             | |   |  \/  |                                 | |
| |  | | ___  _ __| | _____  _   _| |_  | .  . | __ _ _ __   __ _  __ _  ___ _ __| |
| |/\| |/ _ \| '__| |/ / _ \| | | | __| | |\/| |/ _` | '_ \ / _` |/ _` |/ _ \ '__| |
\  /\  / (_) | |  |   < (_) | |_| | |_  | |  | | (_| | | | | (_| | (_| |  __/ |  |_|
 \/  \/ \___/|_|  |_|\_\___/ \__,_|\__| \_|  |_/\__,_|_| |_|\__,_|\__, |\___|_|  (_)
                                                                   __/ |            
                                                                  |___/");

        Console.WriteLine("\nPress Enter to continue to the main menu.");
        Console.ReadLine();
        Console.Clear();
        // Main loop for user interaction =)
        while (true)
        {
            Console.WriteLine(@" _    _            _               _    ___  ___                                  _ 
| |  | |          | |             | |   |  \/  |                                 | |       \ O /
| |  | | ___  _ __| | _____  _   _| |_  | .  . | __ _ _ __   __ _  __ _  ___ _ __| |        \|/
| |/\| |/ _ \| '__| |/ / _ \| | | | __| | |\/| |/ _` | '_ \ / _` |/ _` |/ _ \ '__| |         |
\  /\  / (_) | |  |   < (_) | |_| | |_  | |  | | (_| | | | | (_| | (_| |  __/ |  |_|         |      
 \/  \/ \___/|_|  |_|\_\___/ \__,_|\__| \_|  |_/\__,_|_| |_|\__,_|\__, |\___|_|  (_)        / \     
                                                                   __/ |            
                                                                  |___/                           ");
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add/Delete/View Exercises");
            Console.WriteLine("2. Log/View Workouts");
            Console.WriteLine("3. Log/View Weight and Calories");
            Console.WriteLine("4. Log/View Cardiovascular Exercises");
            Console.WriteLine("5. View Combined Data");
            Console.WriteLine("6. API: Pull Exercise Information");
            Console.WriteLine("7. Exit");

            int choice = GetChoice(1, 7);

            switch (choice)
            {
                case 1:
                    ExerciseManager();
                    break;

                case 2:
                    WorkoutManager();
                    break;

                case 3:
                    WeightAndCaloriesManager();
                    break;

                case 4:
                    CardiovascularManager();
                    break;

                case 5:
                    ViewCombinedData();
                    break;

                case 6:
                    PullExerciseInformation();
                    break;

                case 7:
                    Console.WriteLine(@"
                _____                 _ _                _          
                |  __ \               | | |              | |         
                | |  \/ ___   ___   __| | |__  _   _  ___| |         
                | | __ / _ \ / _ \ / _` | '_ \| | | |/ _ \ |         
                | |_\ \ (_) | (_) | (_| | |_) | |_| |  __/_|         
                \____/\___/ \___/ \__,_|_.__/ \__, |\___(_)         
                                                __/ |                
                                            |___/                 
                _   _                                 _             
                | | | |                               (_)            
                | |_| | __ ___   _____    __ _   _ __  _  ___ ___    
                |  _  |/ _` \ \ / / _ \  / _` | | '_ \| |/ __/ _ \   
                | | | | (_| |\ V /  __/ | (_| | | | | | | (_|  __/   
                \_| |_/\__,_| \_/ \___|  \__,_| |_| |_|_|\___\___|   
                                                                    
                                                                    
                _    _  ___________ _   _______ _   _ _____ _   __  
                | |  | ||  _  | ___ \ | / /  _  | | | |_   _| |  \ \ 
                | |  | || | | | |_/ / |/ /| | | | | | | | | | | (_) |
                | |/\| || | | |    /|    \| | | | | | | | | | |   | |
                \  /\  /\ \_/ / |\ \| |\  \ \_/ / |_| | | | |_|  _| |
                \/  \/  \___/\_| \_\_| \_/\___/ \___/  \_/ (_) (_) |
                                                                /_/ 
                                                     
");
                    return;
            }

            // Prompts the user to press Enter before returning to the main menu! :) 
            Console.WriteLine("\nPress Enter to return to the main menu.");
            Console.ReadLine();
        }
    }
// Super basic introduction menu listed 
    static int GetChoice(int min, int max)
    {
        int choice;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= min && choice <= max)
            {
                return choice;
            }
            Console.WriteLine("Please enter a number between " + min + " and " + max + ".");
        }
    }

    static void ExerciseManager()
    {
        Console.WriteLine("\nExercise Manager:");
        Console.WriteLine("1. Add Exercise");
        Console.WriteLine("2. Delete Exercise");
        Console.WriteLine("3. View Exercises");
        // The three choices allows for the user to add, delete, and view exercises, very simple to use and easy! ^_^
        int choice = GetChoice(1, 3);

        switch (choice)
        {
            case 1:
                AddExercise();
                break;

            case 2:
                DeleteExercise();
                break;

            case 3:
                ViewExercises();
                break;
        }
    }

    static void AddExercise()
    {
        Console.Write("Enter the name of the exercise: ");
        string exerciseName = Console.ReadLine().ToLower(); // Converts to lowercase for case-insensitivity :D

        // Checks if the exercise already exists!
        if (!ExerciseExists(exerciseName))
        {
            // Adds the exercise to the exercises.txt file (Manually created by me originally and not usermade) :(
            File.AppendAllText("exercises.txt", exerciseName + Environment.NewLine);
            Console.WriteLine("Exercise '" + exerciseName + "' successfully added to your workout routine!");
        }
        else
        {
            Console.WriteLine("Exercise '" + exerciseName + "' already exists. No duplicates allowed!");
        }
    }

    static bool ExerciseExists(string exerciseName)
    {
        // Checks if the exercise already exists in the exercises.txt file :]
        string[] exercises = File.ReadAllLines("exercises.txt");
        foreach (var exercise in exercises)
        {
            if (exercise.ToLower() == exerciseName)
            {
                return true; // This means the exercise already exists ^_^
            }
        }
        return false; // This means the exercise does not exist [:
    }

    static void DeleteExercise()
    {
        ViewExercises();

        Console.Write("Enter the name of the exercise to delete: ");
        string exerciseToDelete = Console.ReadLine().ToLower(); // Convert to lowercase for case-insensitivity checks :D 

        // Read all exercises from the file :) 
        List<string> exercises = new List<string>(File.ReadAllLines("exercises.txt"));

        if (exercises.Contains(exerciseToDelete))
        {
            exercises.Remove(exerciseToDelete);

            // Write back the updated exercises to the file (:
            File.WriteAllLines("exercises.txt", exercises);
            Console.WriteLine("Exercise '" + exerciseToDelete + "' has been successfully removed from your workout routine!");
        }
        else
        {
            Console.WriteLine("Exercise '" + exerciseToDelete + "' not found in your workout routine!");
        }
    }

    static void ViewExercises()
    {
        Console.WriteLine("\nList of Exercises:");
        string[] exercises = File.ReadAllLines("exercises.txt");

        foreach (var exercise in exercises)
        {
            Console.WriteLine(exercise);
        }
    }

    static void WorkoutManager()
    {
        Console.WriteLine("\nWorkout Manager:");
        Console.WriteLine("1. Log Workout");
        Console.WriteLine("2. View Workouts");

        int choice = GetChoice(1, 2);

        switch (choice)
        {
            case 1:
                LogWorkout();
                break;

            case 2:
                ViewWorkouts();
                break;
        }
    }

    static void LogWorkout()
    {
        Console.Write("Enter the date of the workout (Month Day Year): ");
        string workoutDate = Console.ReadLine();
        string workoutFileName = workoutDate.Replace(" ", "") + "_workout.txt";

        Console.Write("Enter the number of exercises you did: ");
        int exerciseCount = int.Parse(Console.ReadLine());

        List<string> workoutData = new List<string>();

        for (int i = 0; i < exerciseCount; i++)
        {
            Console.Write("Enter exercise #" + (i + 1) + ": ");
            workoutData.Add(Console.ReadLine().ToLower()); // Converts to lowercase for case-insensitivity <:
        }

        // Write workout data to a file
        File.WriteAllLines(workoutFileName, workoutData);

        Console.WriteLine("Great job! Your workout on " + workoutDate + " has been successfully logged!");
    }

//The below method displays the user's workout for a specific day. :)
    static void ViewWorkouts()
    {
        Console.Write("Enter a day to view workouts (Month Day Year): ");
        string workoutDate = Console.ReadLine();
        string workoutFileName = workoutDate.Replace(" ", "") + "_workout.txt";

        if (File.Exists(workoutFileName))
        {
            Console.WriteLine("\nYour workout on " + workoutDate + ":");
            string[] workoutData = File.ReadAllLines(workoutFileName);

            foreach (var exercise in workoutData)
            {
                Console.WriteLine(exercise);
            }
        }
        else
        {
            Console.WriteLine("No workout found for " + workoutDate + ".");
        }
    }


// Method that manages and tracks your weight and calorie options :) 
    static void WeightAndCaloriesManager()
    {
        Console.WriteLine("\nWeight and Calories Manager:");
        Console.WriteLine("1. Log Weight and Calories");
        Console.WriteLine("2. View Weight and Calories");

        int choice = GetChoice(1, 2);

        switch (choice)
        {
            case 1:
                LogWeightAndCalories();
                break;

            case 2:
                ViewWeightAndCalories();
                break;
        }
    }

// This method is the one that actually allows the user to log weight and calories. :))
    static void LogWeightAndCalories()
    {
        Console.Write("Enter the date (Month Day Year): ");
        string logDate = Console.ReadLine();
        string logFileName = logDate.Replace(" ", "") + "_weight_calories.txt";

        Console.Write("Enter your weight: ");
        string weight = Console.ReadLine();

        Console.Write("Enter the number of calories consumed: ");
        string calories = Console.ReadLine();

        // Write weight and calories data to a file
        File.WriteAllText(logFileName, "Weight: " + weight + " lbs\nCalories: " + calories + " kcal");

        Console.WriteLine("Your weight and calories for " + logDate + " have been successfully logged!");
    }

//This allows you to view your weight and calories by pulling from the file with the date
    static void ViewWeightAndCalories()
    {
        Console.Write("Enter a day to view weight and calories (Month Day Year): ");
        string logDate = Console.ReadLine();
        string logFileName = logDate.Replace(" ", "") + "_weight_calories.txt";

        if (File.Exists(logFileName))
        {
            Console.WriteLine("\nYour weight and calories on " + logDate + ":");
            string logData = File.ReadAllText(logFileName);
            Console.WriteLine(logData);
        }
        else
        {
            Console.WriteLine("No weight and calories log found for " + logDate + ".");
        }
    }

//This method manages the options for the cardiovascular exercises :O
    static void CardiovascularManager()
    {
        Console.WriteLine("\nCardiovascular Exercise Manager:");
        Console.WriteLine("1. Log Cardiovascular Exercise");
        Console.WriteLine("2. View Cardiovascular Exercises");

        int choice = GetChoice(1, 2);

        switch (choice)
        {
            case 1:
                LogCardiovascularExercise();
                break;

            case 2:
                ViewCardiovascularExercises();
                break;
        }
    }

// This method pertains to the actual options within the Cardiovascular exercises and manages user input ^_^
    static void LogCardiovascularExercise()
    {
        Console.Write("Enter the date (Month Day Year): ");
        string logDate = Console.ReadLine();
        string logFileName = logDate.Replace(" ", "") + "_cardio.txt";

        Console.Write("Enter the cardiovascular exercise: ");
        string cardioExercise = Console.ReadLine().ToLower(); // Convert to lowercase for case-insensitive comparison

        // Write cardiovascular exercise data to a file
        File.AppendAllText(logFileName, cardioExercise + Environment.NewLine);

        Console.WriteLine("Fantastic! Your cardiovascular exercise for " + logDate + " has been successfully logged!");
    }

// This allows to view your days and cardiovascular exercises and is very straightforward :) 
    static void ViewCardiovascularExercises()
    {
        Console.Write("Enter a day to view cardiovascular exercises (Month Day Year): ");
        string logDate = Console.ReadLine();
        string logFileName = logDate.Replace(" ", "") + "_cardio.txt";

        if (File.Exists(logFileName))
        {
            Console.WriteLine("\nYour cardiovascular exercises on " + logDate + ":");
            string[] cardioExercises = File.ReadAllLines(logFileName);

            foreach (var exercise in cardioExercises)
            {
                Console.WriteLine(exercise);
            }
        }
        else
        {
            Console.WriteLine("No cardiovascular exercises found for " + logDate + ".");
        }
    }

// Combined data is done in a very simple way which takes each of the three string dates and adds the info
// This data also chnecks to verify that everything exists, as well as workout, logs, and cardio! :)
// All is accounted for if only some of the options exist (Ex. no log, but workout and cardio is accounted for)
    static void ViewCombinedData()
    {
        Console.WriteLine("\nCombined Data:");

        Console.Write("Enter a day to view combined data (Month Day Year): ");
        string logDate = Console.ReadLine();

        string workoutFileName = logDate.Replace(" ", "") + "_workout.txt";
        string logFileName = logDate.Replace(" ", "") + "_weight_calories.txt";
        string cardioFileName = logDate.Replace(" ", "") + "_cardio.txt";


        if (File.Exists(workoutFileName))
        {
            Console.WriteLine("\nYour workout on " + logDate + ":");
            string[] workoutData = File.ReadAllLines(workoutFileName);

            foreach (var exercise in workoutData)
            {
                Console.WriteLine(exercise);
            }
        }
        else
        {
            Console.WriteLine("No workout found for " + logDate + ".");
        }

        if (File.Exists(logFileName))
        {
            Console.WriteLine("\nYour weight and calories on " + logDate + ":");
            string logData = File.ReadAllText(logFileName);
            Console.WriteLine(logData);
        }
        else
        {
            Console.WriteLine("No weight and calories log found for " + logDate + ".");
        }

        if (File.Exists(cardioFileName))
        {
            Console.WriteLine("\nYour cardiovascular exercises on " + logDate + ":");
            string[] cardioExercises = File.ReadAllLines(cardioFileName);

            foreach (var exercise in cardioExercises)
            {
                Console.WriteLine(exercise);
            }
        }
        else
        {
            Console.WriteLine("No cardiovascular exercises found for " + logDate + ".");
        }
    }


// This is the API section of a code and its an absolute wreck :( BUT IT WORKS!
static void PullExerciseInformation()
    {
        Console.Write("Enter the muscle name to get exercise information: ");
        string muscleName = Console.ReadLine();

        string apiKey = "HmnRfweXV3TBysCtkuwqKg==tOaxILyjjZdmwXSc";
        string apiUrl = "https://api.api-ninjas.com/v1/exercises?muscle=" + muscleName;
        // To use this API correctly, BELOW IS THE WEBSITE which will allow you to know how to search for an exercise group
        // https://api-ninjas.com/api/exercises

        try
        {
            using (HttpClient client = new HttpClient())
            {
                // Adds the API key as a header (Key was miserable to use didn't realize I had to set it as a header based on website information)
                client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string exerciseInfo = response.Content.ReadAsStringAsync().Result;

                    // Deserialize the JSON array :) 
                    using (JsonDocument exercises = JsonDocument.Parse(exerciseInfo))
                    {
                        // Displays the exercise information ^_^
                        foreach (JsonElement exercise in exercises.RootElement.EnumerateArray())
                        {
                            // This displays the information in a way that isn't a massive BLOCK (it was before)
                            Console.WriteLine($"\nExercise Information for Muscle {muscleName}:");
                            Console.WriteLine($"Name: {exercise.GetProperty("name").GetString()}");
                            Console.WriteLine($"Type: {exercise.GetProperty("type").GetString()}");
                            Console.WriteLine($"Muscle: {exercise.GetProperty("muscle").GetString()}");
                            Console.WriteLine($"Equipment: {exercise.GetProperty("equipment").GetString()}");
                            Console.WriteLine($"Difficulty: {exercise.GetProperty("difficulty").GetString()}");
                            Console.WriteLine($"Instructions: {exercise.GetProperty("instructions").GetString()}\n");
                        }
                    }
                }
                else
                {
                    // Gives a status and reason for error :D
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }
        catch (Exception ex)
        {
            // More error handling :) 
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
