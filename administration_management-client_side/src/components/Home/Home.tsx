import React, { useContext, useEffect, useState } from 'react';
import { useLocation, useNavigate, useParams } from 'react-router-dom';
import './Home.css';
import ToolbarNavigation from './ToolbarNavigation';
import { UserContext } from '../../App';
import { CommunityAdministrationContext } from '../MainManager/CommunityAdministrations';

const Home = () => {
    const navigate = useNavigate();
    const params = useParams();
    const location = useLocation();
    const [user, setUser] = useState(location.state);
    const myContext = useContext(UserContext);
    const myCommunityAdministrationContext = useContext(CommunityAdministrationContext);
    
    useEffect(()=>{
        console.log(myCommunityAdministrationContext.currentCommunityAdministration, "communityAdministrationContext.currentCommunityAdministration");
    })
    return (
        <>
            <div id='body'>
                <ToolbarNavigation></ToolbarNavigation>
                <h1 dir='rtl' id='title'>{myContext.userData?.firstName} {myContext.userData?.lastName} ברוך הבא!</h1>
                <div id='impression' dir='rtl'>
                <br></br><br></br><a id='textImpression' dir='rtl'>תזכורת קטנה לגבי הנהלים שלנו...</a><br></br>
                    <ul><br></br>
                        <li>על כל עובד להכנס למערכת באמצעות תעודת הזהות והסיסמה האישיים שלו בלבד.</li><br></br><br></br>
                        <li>אין לאפשר רישום לפעילויות השונות עבור תושבים שלא נרשמו למינהל.</li><br></br><br></br>
                        <li>עובד שנתקל בבעיה טכנית במהלך השימוש במערכת, יפנה לשרה: sara@gmail.com או לאליהו: eli@gmail.com.</li><br></br><br></br>
                        <li>יש לך הערה? הארה? רעיון ליעול המערכת? נשמח לשמוע על כך! פנה למנהל המערכת: manager@communityadministration.co.il.</li>
                    </ul>
                </div>
            </div>
        </>
    )
}
export default Home;






