import React, { useEffect } from 'react';
import './App.css';
import "primereact/resources/themes/lara-light-indigo/theme.css";
import "primereact/resources/primereact.min.css";
// import "primeicons/primeicons.css";
import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom';
import Login from './components/Login/Login';
import ToolbarNavigation from './components/Home/ToolbarNavigation';
import CommunityAdministrations from './components/MainManager/CommunityAdministrations';
import UpdateCommunityAdministration from './components/MainManager/updateCommunityAdministration';
import AddCommunityAdministration from './components/MainManager/AddCommunityAdministration';
import Library from './components/Library/Library';
import PlayingCenter from './components/PlayingCenter/PlayingCenter';
import Courses from './components/Course/Course';
import Activity from './components/Activity/Activity';
import CourseEditing from './components/Course/CourseEditing';
import GetCourseRegistereds from './components/Course/GetCourseRegistereds';
import CourseRegistering from './components/Course/AddCourseRegistered';
import SendMessage from './components/Course/SendMessage';
import ActivityEditing from './components/Activity/ActivityEditing';
import AddCourse from './components/Course/AddCourse';
import EditingUnitTimeOfLibrary from './components/Library/EditingUnitTimeOfLibrary';
import EditingUnitTimeOfPlayingCenter from './components/PlayingCenter/EditingUnitTimeOfPlayingCenter';
import AddUnitTimeOfLibrary from './components/Library/AddUnitTimeOfLibrary';
import ActivityRegistering from './components/Activity/ActivityRegistering';
import ParticipantInActivity from './components/Activity/ParticipantInActivity';
import AddActivity from './components/Activity/AddACtivity';
import Home from './components/Home/Home';
import PersonalArea from './components/PersonalArea/PersonalArea';
import FullViewOfCourse from './components/Course/FullViewOfCourse';
import { useState, createContext, useContext } from "react";
import ReactDOM from "react-dom/client";
import FullViewOfActivity from './components/Activity/FullViewOfActivity';
import User from './interfaces/User';
import LoadingIndicator from './components/Home/LoadingIndicator';
export const UserContext = React.createContext<ContextProps>({
  userData: null,
  setUserData: () => null
});
interface ContextProps {
  readonly userData: User | null;
  readonly setUserData: (userData: User) => void;
}
function App() {
  const [userData, setUserData] = useState<User | null>(null);
  const [isLoading, setIsLoading] = useState(true);
  const value = {
    userData,
    setUserData,
  };
  const user = localStorage.getItem("user");
  const manager = localStorage.getItem("mainManager");
  useEffect(() => {
    if (user)
      setUserData(JSON.parse(user));
    else if (manager)
      setUserData(JSON.parse(manager));
  }, [])

  useEffect(() => {
    if (userData) {
      setIsLoading(false);
    }

  }, [userData]);

  return (
    <>
      <UserContext.Provider value={value}>
        {isLoading ? (
          <LoadingIndicator />) : (
          <BrowserRouter>
            <Routes>
              <Route path="/" element={<Login />} />
              <Route path="/home" element={<Home />} />
              <Route path="/personalArea" element={<PersonalArea />} />
              <Route path="/communityAdministrations" element={<CommunityAdministrations />} />
              <Route path="/updateCommunityAdministration" element={<UpdateCommunityAdministration />} />
              <Route path="/addCommunityAdministration" element={<AddCommunityAdministration />} />
              <Route path="/library" element={<Library />} />
              <Route path="/PlayingCenter" element={<PlayingCenter />} />
              <Route path="/course/:targetAudience" element={user ? <Courses /> : <Navigate to='/' />} />
              <Route path="/activity/:targetAudience" element={<Activity />} />
              <Route path="/courseEditing/:courseId/:courseName" element={<CourseEditing />} />
              <Route path="/addCourse/:targetAudience" element={<AddCourse />} />
              <Route path="/getCourseRegistereds" element={<GetCourseRegistereds />} />
              <Route path="/fullView" element={<FullViewOfCourse />} />
              <Route path="/courseRegistering/:courseId/:courseName" element={<CourseRegistering />} />
              <Route path="/sendMessage" element={<SendMessage />} />
              <Route path="library/unitTimeEditing/:unitTimeId" element={<EditingUnitTimeOfLibrary />} />
              <Route path="playingCenter/unitTimeEditing/:unitTimeId" element={<EditingUnitTimeOfPlayingCenter />} />
              <Route path="/activityEditing/:activityId/:activityName" element={<ActivityEditing />} />
              <Route path="/addUnitTimeOfLibrary" element={<AddUnitTimeOfLibrary />} />
              <Route path="/activityRegistering/:activityId/:activityName" element={<ActivityRegistering />} />
              <Route path="/getParticipantsInActivity" element={<ParticipantInActivity />} />
              <Route path="/addActivity/:targetAudience" element={<AddActivity />} />
              <Route path="/fullViewOfActivity/:communityAdministrationId" element={<FullViewOfActivity />} />
            </Routes>
          </BrowserRouter>)}
      </UserContext.Provider>
    </>
  );
}

export default App;
