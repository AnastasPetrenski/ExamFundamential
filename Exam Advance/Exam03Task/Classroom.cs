﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count { get { return this.students.Count; } }

        public string RegisterStudent(Student student)
        {
            if (students.Count < Capacity)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var studentToDismiss = this.students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            
            if (studentToDismiss != null)
            {
                this.students.Remove(studentToDismiss);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            if (this.students.Any(s => s.Subject == subject))
            {
                StringBuilder sb = new StringBuilder();
                sb
                    .AppendLine($"Subject: {subject}")
                    .AppendLine("Students:");
                foreach (var student in students.Where(s => s.Subject == subject))
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().TrimEnd();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return this.students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return this.students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}
