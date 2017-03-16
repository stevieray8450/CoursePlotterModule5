using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
using System.ComponentModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Faculty : Page
    {
        public Faculty()
        {
            this.InitializeComponent();
            BL_PageContent.CreatedBy = "Created by: Steve Boniface";
            courseFaculty.Text = "";
            txtBoxFooter.Text = BL_PageContent.CreatedBy;

            txtCourse.Text = "Click your class button below to display faculty information.";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // executes Course1 method from BL_PageContent. This loads all relevant data to course 1.
            // this data is then used to fill the txtCourse, courseFaculty, aboutCourse, and coursePrereq text blocks
            BL_PageContent.Course1();

            txtCourse.Text = BL_PageContent.CourseID + "\n" + BL_PageContent.CourseCode + "\n" + BL_PageContent.CourseTitle;
            courseFaculty.Text = BL_PageContent.FacultyMember;
            aboutCourse.Text = BL_PageContent.AboutCourse;
            coursePrereq.Text = BL_PageContent.CreditsPrereq;

            // sending the correct image file path to the courseFacultyPic "placeholder" in the XAML file
            courseFacultyPic.Source = new BitmapImage(new Uri(courseFacultyPic.BaseUri, "syedNabeel.png"));
        }

        private void course2Btn_Click(object sender, RoutedEventArgs e)
        {
            // executes Course2 method from BL_PageContent. This loads all relevant data to course 2.
            // this data is then used to fill the txtCourse, courseFaculty, aboutCourse, and coursePrereq text blocks
            BL_PageContent.Course2();

            txtCourse.Text = BL_PageContent.CourseID + "\n" + BL_PageContent.CourseCode + "\n" + BL_PageContent.CourseTitle;
            courseFaculty.Text = BL_PageContent.FacultyMember;
            aboutCourse.Text = BL_PageContent.AboutCourse;
            coursePrereq.Text = BL_PageContent.CreditsPrereq;

            // sending the correct image file path to the courseFacultyPic "placeholder" in the XAML file
            courseFacultyPic.Source = new BitmapImage(new Uri(courseFacultyPic.BaseUri, "cynthiaMoonhowler.png"));
        }

        private void course3Btn_Click(object sender, RoutedEventArgs e)
        {
            // executes Course3 method from BL_PageContent. This loads all relevant data to course 3.
            // this data is then used to fill the txtCourse, courseFaculty, aboutCourse, and coursePrereq text blocks.
            BL_PageContent.Course3();

            txtCourse.Text = BL_PageContent.CourseID + "\n" + BL_PageContent.CourseCode + "\n" + BL_PageContent.CourseTitle;
            courseFaculty.Text = BL_PageContent.FacultyMember;
            aboutCourse.Text = BL_PageContent.AboutCourse;
            coursePrereq.Text = BL_PageContent.CreditsPrereq;

            // sending the correct image file path to the courseFacultyPic "placeholder" in the XAML file
            courseFacultyPic.Source = new BitmapImage(new Uri(courseFacultyPic.BaseUri, "shadMcdillek.jpeg"));
        }

    }
}
