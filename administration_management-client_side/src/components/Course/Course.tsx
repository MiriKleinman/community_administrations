import React, { useContext, useEffect, useMemo, useState } from 'react';
import { useLocation, useNavigate, useParams } from 'react-router-dom';
import Course from '../../interfaces/Course';
import CourseService from '../../Services/CourseService';
import { GridToolbar } from '@mui/x-data-grid';
import { DataGrid } from '@mui/x-data-grid';
import deleteIcon from '../../images/deleteIcon.png';
import messageIcon from '../../images/messageIcon.png';
import './Course.css';
import ToolbarNavigation from '../Home/ToolbarNavigation';
import course from '../../images/iconCourse.png';
import search from '../../images/search.png';
import { DataSaverOnRounded } from '@mui/icons-material';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';
import Drawer from '@mui/material/Drawer';
import Divider from '@mui/material/Divider';
import AddCourse from './AddCourse';
import CourseEditing from './CourseEditing';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import Button from '@mui/material/Button';
import { UserContext } from '../../App';
import SendMessage from './SendMessage';
import FullViewOfCourse from './FullViewOfCourse';
import close from '../../images/close.png';


type Anchor = 'top' | 'left' | 'bottom' | 'right';
var res: any;
export const CourseContext = React.createContext<ContextProps>({
    courseData: null,
    currentCourse: null,
    setCourseData: () => null,
    setCurrentCourse: () => null
});
interface ContextProps {
    readonly courseData: Course[] | null;
    readonly currentCourse: Course | null;
    readonly setCourseData: (courseData: Course[]) => void;
    readonly setCurrentCourse: (currentCourse: Course) => void;
}
const Courses = () => {
    var coursesList: any;
    var courseRegistereds: any;
    const params = useParams();
    const navigate = useNavigate();
    const location = useLocation();
    const myContext = useContext(UserContext);
    const [fullViewFlag, setFullViewFlag] = useState(false);
    // const courseContext = useContext(CourseContext);
    const [dataCourses, setDataCourses] = useState<any[]>([]);
    const [stateCourses, setStateCourses] = useState<any[]>([]);
    const [courseArray, setCourseArray] = useState<any[]>([]);
    const [courseDetails, setCourseDetails] = useState<Course>();
    const [open, setOpen] = useState(false);
    const [status, setStatus] = useState();
    const [isLoading, setIsLoading] = useState(true);
    const [state, setState] = useState<{
        left: boolean;
        activePopup: 'addCourse' | 'courseEditing' | 'sendMessage' | null;
    }>
        ({
            left: false,
            activePopup: null,
        });
    const [courseData, setCourseData] = useState<Course[] | null>(null);
    const value = {
        courseData,
        setCourseData,
    };
    const [currentCourse, setCurrentCourse] = useState<Course | null>(null);
    const currentCourseValue = {
        currentCourse,
        setCurrentCourse,
    };
    const handleClose = () => {
        setOpen(false);
    };

    const toggleDrawerAddCourse = (open: boolean) => {
        setState({ ...state, left: open, activePopup: 'addCourse' });
    };

    const toggleDrawerEditCourse = (open: boolean) => {
        setState({ ...state, left: open, activePopup: 'courseEditing' });
    };
    const toggleDrawerSendMessage = (open: boolean) => {
        setState({ ...state, left: open, activePopup: 'sendMessage' });
    };
    const listAddCourse = (anchor: Anchor) => (
        <Box
            sx={{ width: anchor === 'top' || anchor === 'bottom' ? 'auto' : 250 }}
            role="presentation"
            onClick={() => toggleDrawerAddCourse(true)}
            onKeyDown={() => toggleDrawerAddCourse(true)}
        >
            <Divider />
        </Box>
    );

    const listEditCourse = (anchor: Anchor) => (
        <Box
            sx={{ width: anchor === 'top' || anchor === 'bottom' ? 'auto' : 250 }}
            role="presentation"
            onClick={() => toggleDrawerEditCourse(true)}
            onKeyDown={() => toggleDrawerEditCourse(true)}
        >
            <Divider />
        </Box>
    );
    const listSendMessage = (anchor: Anchor) => (
        <Box
            sx={{ width: anchor === 'top' || anchor === 'bottom' ? 'auto' : 250 }}
            role="presentation"
            onClick={() => toggleDrawerAddCourse(true)}
            onKeyDown={() => toggleDrawerAddCourse(true)}
        >
            <Divider />
        </Box>
    );
    const getCourses = async () => {
        return await CourseService.getCoursesByTargetAudience(myContext.userData?.communityAdministrationId, params.targetAudience || location.state.course.targetAudience).then((res: any) => {
            coursesList = res;
            setCourseArray(res);
            console.log(coursesList, "coursesList getCourses");
            return coursesList;
        })
    }
    const checkForDelete = async (row: any) => {
        setCourseDetails(row);
        res = await CourseService.checkForDelete(row.courseId, myContext.userData?.userId);
        console.log(res, "res");
        setStatus(res && res);
        setOpen(true);
        await fetchData();
        console.log(res, "result of delete");
    };
    const deleteCourse = async () => {
        console.log(courseDetails, "course");
        if (courseDetails) {
            await CourseService.deleteCourse(courseDetails.courseId, myContext.userData?.userId);
            handleClose();
            fetchData();
        }
    }
    const editCourse = (row: any) => {
        setCurrentCourse(row);
        toggleDrawerEditCourse(true);
    }
    const addCourseRegistered = (e: any, row: any) => {
        navigate(`/courseRegistering/${row.courseId}/${row.courseName}`, { state: myContext.userData })
    }
    const checkNumberOfParticipants = async (courseId: number) => {
        return await CourseService.checkNumberOfParticipants(courseId);
    }
    const getCourseRegistereds = async (e: any, row: any) => {
        navigate(`/getCourseRegistereds`, { state: await CourseService.getCourseRegistereds(row.courseId, myContext.userData?.userId) })
    }
    const sendMessage = (row: any) => {
        setCurrentCourse(row);
        toggleDrawerSendMessage(true);
    }
    const addCourse = async () => {
        console.log(myContext.userData);
        navigate(`/addCourse/${params.targetAudience}`)
    }
    const search = (courseName: string) => {
        var filteredCourse = courseArray.filter((course: any) => {
            return course.courseName.includes(courseName)
        })
        setDataCourses(filteredCourse);
    }
    const fullView = async (row: any) => {
        setCurrentCourse(row);
        setFullViewFlag(true);
    }
    const fetchData = async () => {
        debugger
        var data = await getCourses();
        console.log(data, "data");
        var stateCourse: number[] = [];
        data.forEach(async (course: Course) => {
            await checkNumberOfParticipants(course.courseId).then((courseRes) => stateCourse.push(courseRes.data));
            console.log(stateCourse, "stateCourse in foreach");
            setStateCourses(stateCourse);
        });
        setDataCourses([...data]);
        setCourseData([...data]);
    }
    useEffect(() => {
        fetchData();
        console.log(myContext.userData, "myContext.userData");
        console.log(courseData, "myContext.courseData");
        console.log(dataCourses, "datacourses");
    }, [params.targetAudienc, currentCourse]);

    useEffect(() => {

    }, [fullViewFlag])

    useEffect(() => {

    }, [CourseContext])
    return (
        <>
            <CourseContext.Provider value={{ courseData, setCourseData, currentCourse, setCurrentCourse }}>
                {fullViewFlag ? <FullViewOfCourse></FullViewOfCourse> :
                    <div>
                        <div id='courseBody'>
                            <ToolbarNavigation></ToolbarNavigation>
                            <img id='iconCourse' src={course}></img>
                            <h3 className='courseTitle'>מערכת חוגים עדכנית ל{params.targetAudience}</h3>
                            <h3 className='courseSubTitle'>מידע שוטף והרשמה למגוון החוגים הרחב</h3>
                        </div>
                        <input type="text" dir='rtl' placeholder='    לחיפוש חוג...' id='search' onChange={(e: any) => search(e.target.value)}></input>
                        <TableContainer id='table' component={Paper}>
                            <Table sx={{ minWidth: 100 }} aria-label="simple table">
                                <TableHead>
                                    <TableRow>
                                        <TableCell align="left" ></TableCell>
                                        <TableCell align="left" ></TableCell>
                                        <TableCell align="left" ></TableCell>
                                        <TableCell align="left" ></TableCell>
                                        <TableCell align="left">הערות</TableCell>
                                        <TableCell align="left"> כמות מקסימלית</TableCell>
                                        <TableCell align="left">מספר נרשמים </TableCell>
                                        <TableCell align="left">עלות</TableCell>
                                        <TableCell align="left">מפעיל/ה</TableCell>
                                        <TableCell align="left">זמן</TableCell>
                                        <TableCell align="left">שם החוג</TableCell>
                                        {/* <TableCell align="left">לוגו </TableCell> */}
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {dataCourses && dataCourses.map((row, i) => (
                                        <TableRow
                                            key={row.courseId}
                                            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                                        >
                                            <TableCell align="left"><a onClick={() => checkForDelete(row)} className='deleteClick'><img src={deleteIcon}></img></a></TableCell>
                                            <TableCell align="left"><a onClick={() => sendMessage(row)} className='messageClick'><img src={messageIcon}></img></a></TableCell>
                                            <TableCell align="left"><a onClick={() => editCourse(row)} className="editCourseLink">עריכה</a></TableCell>
                                            <TableCell align="left"><a onClick={() => fullView(row)} className="displayCourseLink">צפייה בפרטי החוג</a></TableCell>
                                            <TableCell align="left">{row.remarks}</TableCell>
                                            <TableCell align="left">{row.maxParticipants}</TableCell>
                                            <TableCell align="left">{row.courseRegistereds.length}</TableCell>
                                            <TableCell align="left">{row.costForLesson}</TableCell>
                                            <TableCell align="left">{row.operatorName}</TableCell>
                                            <TableCell align="left">{row.day}<br></br>{row.beginngTime} - {row.endTime}</TableCell>
                                            <TableCell align="left">{row.courseName}</TableCell>
                                            {/* <TableCell align="left"><img id='imgCourse' src={`https://localhost:7233/${row.logo}`}></img></TableCell> */}
                                        </TableRow>
                                    ))}
                                </TableBody>
                            </Table>
                        </TableContainer>
                        <React.Fragment key="left">
                            <button id="addCourse" onClick={() => toggleDrawerAddCourse(true)}>
                                להוספת חוג
                            </button>
                            {state.activePopup === 'addCourse' && (
                                <Drawer
                                    anchor="left"
                                    open={state.left}
                                    onClose={() => toggleDrawerAddCourse(false)}
                                >
                                    {listAddCourse('left')}
                                    <img src={close} className='closePageIcon' onClick={() => toggleDrawerAddCourse(false)}></img>
                                    <AddCourse />
                                </Drawer>
                            )}
                        </React.Fragment>
                        <React.Fragment key="left">
                            {state.activePopup === 'courseEditing' && (
                                <Drawer
                                    anchor="left"
                                    open={state.left}
                                    onClose={() => toggleDrawerEditCourse(false)}
                                >
                                    {listEditCourse('left')}
                                    <img src={close} className='closePageIcon' onClick={() => toggleDrawerEditCourse(false)}></img>
                                    <CourseEditing />
                                </Drawer>
                            )}
                        </React.Fragment>
                        <React.Fragment key="left">
                            {state.activePopup === 'sendMessage' && (
                                <Drawer
                                    anchor="left"
                                    open={state.left}
                                    onClose={() => toggleDrawerSendMessage(false)}
                                >
                                    {listSendMessage('left')}
                                    <img src={close} className='closePageIcon' onClick={() => toggleDrawerSendMessage(false)}></img>
                                    <SendMessage />
                                </Drawer>
                            )}
                        </React.Fragment>
                        {status ?
                            <Dialog
                                open={open}
                                onClose={handleClose}
                                aria-labelledby="alert-dialog-title"
                                aria-describedby="alert-dialog-description"
                            >
                                <DialogTitle id="alert-dialog-title" dir="rtl">
                                    {"האם אתה בטוח שברצונך למחוק את החוג?"}
                                </DialogTitle>
                                <DialogContent>
                                    <DialogContentText id="alert-dialog-description" dir="rtl">
                                        אם תאשר את המחיקה, החוג ימחק לנצח ולא תהיה אפשרות לשחזר אותו.
                                    </DialogContentText>
                                </DialogContent>
                                <DialogActions dir="rtl">
                                    <Button onClick={handleClose} autoFocus >אל תמחק</Button>
                                    <Button onClick={() => deleteCourse()} >
                                        בסדר, מוכן
                                    </Button>
                                </DialogActions>
                            </Dialog> :
                            <Dialog
                                open={open}
                                onClose={handleClose}
                                aria-labelledby="alert-dialog-title"
                                aria-describedby="alert-dialog-description"
                            >
                                <DialogTitle id="alert-dialog-title" dir="rtl">
                                    {"אין אפשרות למחוק את החוג"}
                                </DialogTitle>
                                <DialogContent>
                                    <DialogContentText id="alert-dialog-description" dir="rtl">
                                        יש נרשמים לחוג, או שאין לך את ההרשאות למחיקת חוג.
                                    </DialogContentText>
                                </DialogContent>
                                <DialogActions dir="rtl">
                                    <Button onClick={handleClose} autoFocus dir="rtl">
                                        קבלתי, תודה
                                    </Button>
                                </DialogActions>
                            </Dialog>
                        }
                    </div>}
            </CourseContext.Provider>
        </>
    )
}
export default Courses;

