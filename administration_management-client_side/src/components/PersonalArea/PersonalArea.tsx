import React, { useContext, useEffect, useState } from 'react';
import { useLocation, useNavigate, useParams } from 'react-router-dom';
import { useFormik } from 'formik';
import UnitTimeOfLibrary from '../../interfaces/UnitTimeOfLibrary';
import LibraryService from '../../Services/LibraryService';
import personalArea from '../../images/personalArea.png';
import ToolbarNavigation from '../Home/ToolbarNavigation';
import './PersonalArea.css';
import User from '../../interfaces/User';
import UserService from '../../Services/UserService';
import { UserContext } from '../../App';

const PersonalArea = () => {
    const location = useLocation();
    const [status, setStatus] = useState(0);
    let libraryId: number;
    const myContext = useContext(UserContext);

    const navigate = useNavigate();
    const validate = (values: any) => {
        const errors: any = {};
        if (!values.firstName) {
            errors.firstName = 'שדה חובה';
        }

        if (!values.lastName) {
            errors.lastName = 'שדה חובה';
        }

        if (!values.email) {
            errors.email = 'שדה חובה';
        }
        if (!values.phone) {
            errors.phone = 'שדה חובה';
        }
        return errors;
    };
    const formik = useFormik({
        initialValues: {
            firstName: String(myContext.userData?.firstName),
            lastName: String(myContext.userData?.lastName),
            email: String(myContext.userData?.email),
            phone: String(myContext.userData?.phone)
        },
        validate,
        onSubmit: values => {
            save();
        },
    });
    const save = async () => {
        debugger
        console.log("save updatePersonal");
        const user: User = new User();
        user.userId = String(myContext.userData?.userId);
        user.password = String(myContext.userData?.password);
        user.communityAdministrationId = String(myContext.userData?.communityAdministrationId);
        user.firstName = formik.values.firstName;
        user.lastName = formik.values.lastName;
        user.email = formik.values.email;
        user.phone = formik.values.phone;
        user.isManager = Boolean(myContext.userData?.isManager);
        console.log(user, "user");
        await UserService.updateUser(user.userId, user.password, user)
            .then((res: any) => {
                setStatus(res);
            })
    }
    return (
        <>
            <div id='body'>
                <ToolbarNavigation></ToolbarNavigation>
                <img className='personalAreaIcon' src={personalArea}></img>
                <h1 className='titlePersonalArea'>עריכת פרופיל </h1>
                <h1 className='subTitlePersonalArea'>עריכה, שינוי ועדכון פרטי העובד</h1>
                <form onSubmit={formik.handleSubmit} dir="rtl" className='formUpdateUser'>
                    <label className='label' htmlFor="firstName">שם פרטי</label><br></br><br></br>
                    <input className="firstName" name="firstName" type="text" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.firstName} /><br></br><br></br><br></br>
                    {formik.touched.firstName && formik.errors.firstName ? <div id='error'>{formik.errors.firstName}</div> : null}
                    <label className='label' htmlFor="lastName">שם משפחה</label><br></br><br></br>
                    <input className="lastName" name="lastName" type="text" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.lastName} /><br></br><br></br><br></br>
                    {formik.touched.lastName && formik.errors.lastName ? <div id='error'>{formik.errors.lastName}</div> : null}
                    <label className='label' htmlFor="email">דוא"ל </label><br></br><br></br>
                    <input className="email" name="email" type="text" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.email} /><br></br><br></br><br></br>
                    {formik.touched.email && formik.errors.email ? <div id='error'>{formik.errors.email}</div> : null}
                    <label className='label' htmlFor="phone">טלפון </label><br></br><br></br>
                    <input className="phone" name="phone" type="text" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.phone} /><br></br><br></br><br></br>
                    {formik.touched.phone && formik.errors.phone ? <div id='error'>{formik.errors.phone}</div> : null}
                    <button type="submit" className='sendPersonalChangesBtn'>לשמירה</button>
                    {status === 1 && <h3 className='successEditPersonalDetails'>פרטיך התעדכנו בהצלחה!</h3>}
                </form>
            </div>
        </>
    )
}
export default PersonalArea;
