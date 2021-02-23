using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoursePlanning
{
    class Program
    {
        static void Main()
        {
            List<string> lessons = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "course start")
            {
                string[] line = input
                    .Split(':', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = line[0];
                string lessonTitle = line[1];
                bool lessonTitleExist = false;
                string exerciseLesson = lessonTitle + "-Exercise";
                bool exerciseLessonExist = false;

                if (lessons.IndexOf(lessonTitle) >= 0)
                {
                    lessonTitleExist = true;
                }

                if (lessons.IndexOf(exerciseLesson) >= 0)
                {
                    exerciseLessonExist = true;
                }

                if (command == "Add")
                {
                    if(lessonTitleExist == false)
                    {
                        lessons.Add(lessonTitle);
                    }
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(line[2]);

                    if (lessonTitleExist == false)
                    {
                        lessons.Insert(index, lessonTitle);
                    }
                }
                else if (command == "Remove")
                {
                    if (lessonTitleExist)
                    {
                        lessons.Remove(lessonTitle);
                    }
                }
                else if (command == "Swap")
                {
                    string otherLesson = line[2];

                    if (lessonTitleExist)
                    {
                        if(lessons.IndexOf(otherLesson) >= 0)
                        {
                            int firstLessonIndex = lessons.IndexOf(lessonTitle);
                            int secondLessonIndex = lessons.IndexOf(otherLesson);

                            lessons[firstLessonIndex] = otherLesson;
                            lessons[secondLessonIndex] = lessonTitle;

                            string otherLessonExercise = otherLesson + "-Exercise";
                            int otherLessonExerciseIndex = lessons.IndexOf(otherLessonExercise);

                            if (otherLessonExerciseIndex >= 0)
                            {
                                lessons.Remove(otherLessonExercise);
                                lessons.Insert(lessons.IndexOf(otherLesson) + 1, otherLessonExercise);
                            }
                            if (exerciseLessonExist)
                            {
                                lessons.Remove(exerciseLesson);
                                lessons.Insert(lessons.IndexOf(lessonTitle) + 1, lessonTitle);
                            }
                        }
                    }
                }
                else
                {
                    if (lessonTitleExist)
                    {
                        if (exerciseLessonExist == false)
                        {
                            int lessonTitleIndex = lessons.IndexOf(lessonTitle);
                            lessons.Insert(lessonTitleIndex + 1, exerciseLesson);
                        }
                    }
                    else
                    {
                        lessons.Add(lessonTitle);
                        lessons.Add(exerciseLesson);
                    }
                }
                input = Console.ReadLine();
            }

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }
    }
}
