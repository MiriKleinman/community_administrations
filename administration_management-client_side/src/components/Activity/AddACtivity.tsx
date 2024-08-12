import React, { useEffect, useState } from 'react';
import { useFormik } from 'formik';
import { useLocation, useNavigate, useParams } from "react-router-dom";
import User from '../../interfaces/User';
import CourseRegistered from '../../interfaces/CourseRegistered';
import CourseService from '../../Services/CourseService';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import Paper, { PaperProps } from '@mui/material/Paper';
import { dir } from 'console';
import Course from '../../interfaces/Course';
import { DatePicker, LocalizationProvider } from '@mui/x-date-pickers';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { Box, Button, IconButton, Menu, MenuItem } from "@mui/material";
import UploadOutlinedIcon from "@mui/icons-material/UploadOutlined";
import { Tooltip } from '@mui/material'
import Activity from '../../interfaces/Activity';
import ActivityService from '../../Services/ActivityService';
import './AddActivity.css';
const AddActivity = () => {
    const navigate = useNavigate();
    const params = useParams();
    const [status, setStatus] = useState(0);
    const location = useLocation()
    const validate = (values: any) => {
        const errors: any = {};
        if (!values.activityName) {
            errors.activityName = 'שדה חובה';
        }
        if (!values.description) {
            errors.description = 'שדה חובה';
        }

        if (!values.maxParticipants) {
            errors.maxParticipants = 'שדה חובה';
        }
        if (!values.day) {
            errors.day = 'שדה חובה';
        }
        if (!values.beginngTime) {
            errors.beginngTime = 'שדה חובה';
        }
        if (!values.endTime) {
            errors.endTime = 'שדה חובה';
        }
        if (!values.endTimeOfPreview) {
            errors.endTimeOfPreview = 'שדה חובה';
        }
        if (!values.date) {
            errors.date = 'שדה חובה';
        }
        return errors;
    };
    const formik = useFormik({
        initialValues: {
            activityName: '',
            description: '',
            cost: 0,
            maxParticipants: 0,
            endTimeOfPreview: new Date().toLocaleDateString('en-CA'),
            day: '',
            beginngTime: '',
            endTime: '',
            date: ''

        },
        validate,
        onSubmit: values => {
            save();
        },
    });

    const save = async () => {
        debugger
        console.log("save addActivity");
        console.log();
        const activity: Activity = new Activity();
        console.log(location.state.communityAdministrationId);
        activity.communityAdministrationId = String(location.state.communityAdministrationId);
        activity.activityName = formik.values.activityName;
        activity.description = formik.values.description;
        activity.targetAudience = params.targetAudience || '';
        activity.cost = formik.values.cost;
        activity.maxParticipants = formik.values.maxParticipants;
        activity.day = formik.values.day;
        activity.beginngTime = formik.values.beginngTime;
        activity.endTime = formik.values.endTime;
        activity.date = formik.values.date;
        activity.endTimeOfPreview = new Date((formik.values.endTimeOfPreview).toString());
        console.log(activity, "activity");
        await ActivityService.addActivity(location.state.userId, activity)
            .then((res: any) => {
                setStatus(res);
            })
    }
    return (
        <>
            <div id='body'>
                <h3 id='title'> הוספת פעילות </h3>
                <form id="form" onSubmit={formik.handleSubmit} dir="rtl">
                    <label id="label" htmlFor="activityName"> הפעילות</label><br></br>
                    <input id="activityName" name="activityName" type="text" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.activityName} /><br></br>
                    {formik.touched.activityName && formik.errors.activityName ? <div>{formik.errors.activityName}</div> : null}
                    <label id="label" htmlFor="description">תאור </label><br></br>
                    <input id="description" name="description" type="text" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.description} /><br></br>
                    {formik.touched.description && formik.errors.description ? <div>{formik.errors.description}</div> : null}
                    <label id="label" htmlFor="cost"> מחיר</label><br></br>
                    <input id="cost" name="cost" type="number" min={0} onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.cost} /><br></br>
                    <label id="label" htmlFor="maxParticipants">מספר משתתפים מקסימלי </label><br></br>
                    <input id="maxParticipants" name="maxParticipants" type="number" min={1} onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.maxParticipants} /><br></br>
                    {formik.touched.maxParticipants && formik.errors.maxParticipants ? <div>{formik.errors.maxParticipants}</div> : null}
                    <label id="label" htmlFor="date">תאריך</label><br></br>
                    <input id="date" name="date" type="text" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.date} /><br></br>
                    {formik.touched.date && formik.errors.date ? <div>{formik.errors.date}</div> : null}
                    <label id="label" htmlFor="day">יום</label><br></br>
                    <select id="day" name="day" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.day} >
                        <option>ראשון</option>
                        <option>שני</option>
                        <option>שלישי</option>
                        <option>רביעי</option>
                        <option>חמישי</option>
                    </select><br></br>
                    {formik.touched.day && formik.errors.day ? <div>{formik.errors.day}</div> : null}
                    <label id="label" htmlFor="beginngTime">זמן התחלה </label><br></br>
                    <input id="beginngTime" name="beginngTime" type="text" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.beginngTime} /><br></br>
                    {formik.touched.beginngTime && formik.errors.beginngTime ? <div>{formik.errors.beginngTime}</div> : null}
                    <label id="label" htmlFor="endTime">זמן סיום </label><br></br>
                    <input id="endTime" name="endTime" type="text" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.endTime} /><br></br>
                    {formik.touched.endTime && formik.errors.endTime ? <div>{formik.errors.endTime}</div> : null}
                    <label id="label" htmlFor="endTimeOfPreview" dir="rtl">עד מתי תוצג הפעילות?</label><br></br>
                    <input id="endTimeOfPreview" name="endTimeOfPreview" type="date" onChange={formik.handleChange} onBlur={formik.handleBlur} value={(formik.values.endTimeOfPreview)} /><br></br>
                    {formik.touched.endTimeOfPreview && formik.errors.endTimeOfPreview ? <div>{formik.errors.endTimeOfPreview}</div> : null}
                    <button id="save" type="submit">פרסם</button>
                    {status === 1 && <h3>{formik.values.activityName} נוסף בהצלחה</h3>}
                </form>
            </div>

        </>
    )
}
export default AddActivity;


