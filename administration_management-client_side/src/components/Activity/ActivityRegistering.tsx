import React, { useContext, useEffect, useState } from 'react';
import { useFormik } from 'formik';
import { useLocation, useNavigate, useParams } from "react-router-dom";
import User from '../../interfaces/User';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import Paper, { PaperProps } from '@mui/material/Paper';
import { dir } from 'console';
import ParticipantInActivity from '../../interfaces/ParticipantInActivity';
import ActivityService from '../../Services/ActivityService';
import { ActivityContext } from './Activity';
import './ActivityRegistering.css';

const ActivityRegistering = () => {
    const navigate = useNavigate();
    const params = useParams();
    const [status, setStatus] = useState(0);
    const location = useLocation();
    const activityContext = useContext(ActivityContext);
    const validate = (values: any) => {
        const errors: any = {};
        if (!values.userId) {
            errors.userId = 'שדה חובה';
        } else if (values.userId.length != 9) {
            errors.userId = 'תעודת זהות חייבת להכיל 9 ספרות';
        }

        if (!values.firstName) {
            errors.firstName = 'שדה חובה';
        }

        if (!values.lastName) {
            errors.lastName = 'שדה חובה';
        }

        if (!values.email) {
            errors.email = 'שדה חובה';
        } else if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i.test(values.email)) {
            errors.email = 'כתובת מייל לא חוקית';
        }
        if (!values.phone) {
            errors.phone = 'שדה חובה';
        }
        else if (values.phone.length > 10 || values.phone.length < 7)
            errors.phone = 'מספר טלפון לא חוקי'
        return errors;
    };
    const formik = useFormik({
        initialValues: {
            userId: '',
            firstName: '',
            lastName: '',
            email: '',
            phone: ''
        },
        validate,
        onSubmit: values => {
            save();
        },
    });

    const save = async () => {
        console.log("save activityRegistering");
        const participantInActivity: ParticipantInActivity = new ParticipantInActivity();
        participantInActivity.userId = formik.values.userId || "";
        participantInActivity.activityId = Number(activityContext.currentActivity?.activityId);
        participantInActivity.firstName = formik.values.firstName;
        participantInActivity.lastName = formik.values.lastName;
        participantInActivity.email = formik.values.email;
        participantInActivity.phone = formik.values.phone;
        debugger
        await ActivityService.addParticipantToActivity(participantInActivity, participantInActivity.userId)
            .then((res: any) => {
                setStatus(res);
            })
    }


    return (
        <>
            {status === 1 ? <h3 className='successAddingParticipant' dir='rtl'> {formik.values.firstName} {formik.values.lastName} נוסף בהצלחה!</h3> :
                <>
                    <h3 className='addParticipantTitle'>רישום ל{activityContext.currentActivity?.activityName}</h3><br></br><form onSubmit={formik.handleSubmit} dir="rtl" className='formAddParticipant'>
                        <label htmlFor="userId">תעודת זהות</label><br></br><br></br>
                        <input id="userId" name="userId" type="text" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.userId} /><br></br><br></br>
                        {formik.touched.userId && formik.errors.userId ? <div>{formik.errors.userId}</div> : null}
                        <label htmlFor="firstName">שם פרטי</label><br></br><br></br>
                        <input id="firstName" name="firstName" type="text" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.firstName} /><br></br><br></br>
                        {formik.touched.firstName && formik.errors.firstName ? <div>{formik.errors.firstName}</div> : null}
                        <label htmlFor="lastName">שם משפחה</label><br></br><br></br>
                        <input id="lastName" name="lastName" type="text" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.lastName} /><br></br><br></br>
                        {formik.touched.lastName && formik.errors.lastName ? <div>{formik.errors.lastName}</div> : null}
                        <label htmlFor="email">מייל</label><br></br><br></br>
                        <input id="email" name="email" type="text" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.email} /><br></br><br></br>
                        {formik.touched.email && formik.errors.email ? <div>{formik.errors.email}</div> : null}
                        <label htmlFor="phone">טלפון</label><br></br><br></br>
                        <input id="phone" name="phone" type="text" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.phone} /><br></br><br></br>
                        {formik.touched.phone && formik.errors.phone ? <div>{formik.errors.phone}</div> : null}<br></br>
                        <button type="submit" className='saveNewParticipant'>לשמירה</button>
                    </form>
                </>
            }
        </>
    )
}
export default ActivityRegistering;


