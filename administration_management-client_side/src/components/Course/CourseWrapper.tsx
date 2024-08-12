import React, { ReactNode } from 'react';
import { CourseContext } from './Course';
import Course from '../../interfaces/Course';

interface CourseContextWrapperProps {
    children: ReactNode;
}

const CourseContextWrapper: React.FC<CourseContextWrapperProps> = ({ children }) => {
    // const courseData: Course[] | null = [];
    // const currentCourse: Course | null = {};

    return (<></>
        // <CourseContext.Provider value={{ courseData, currentCourse }}>
        //     {children}
        // </CourseContext.Provider>
    );
};

export default CourseContextWrapper;