import { useLocation, useNavigate, useParams } from "react-router-dom";
import PlayingCenterService from "../../Services/PlayingCenterService";
import React, { useEffect, useMemo, useState } from 'react';
import ToolbarNavigation from "../Home/ToolbarNavigation";
import deleteIcon from '../../images/deleteIcon.png';
import './PlayingCenter.css';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';
import Drawer from '@mui/material/Drawer';
import Divider from '@mui/material/Divider';
import AddUnitTimeOfPlayingCenter from "./AddUnitTimeOfPlayingCenter";
import iconPlayingCenter from '../../images/iconPlayingCenter.png';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import Button from '@mui/material/Button';
import { BaseToolbarProps } from "@mui/x-date-pickers/internals";
import UnitTimeOfPlayingCenter from "../../interfaces/UnitTimeOfPlayingCenter";
import close from '../../images/close.png';
import EditingUnitTimeOfPlayingCenter from "./EditingUnitTimeOfPlayingCenter";

export const PlayingCenterContext = React.createContext<ContextProps>({
    playingCenterData: null,
    currentUnitTime: null,
    setPlayingCenterData: () => null,
    setCurrentUnitTime: () => null
});
interface ContextProps {
    readonly playingCenterData: UnitTimeOfPlayingCenter[] | null;
    readonly currentUnitTime: UnitTimeOfPlayingCenter | null;
    readonly setPlayingCenterData: (playingCenterData: UnitTimeOfPlayingCenter[]) => void;
    readonly setCurrentUnitTime: (currentUnitTime: UnitTimeOfPlayingCenter) => void;
}
type Anchor = 'top' | 'left' | 'bottom' | 'right';
const PlayingCenter = () => {
    const params = useParams();
    const location = useLocation();
    const navigate = useNavigate();
    var checkDeleteUnitTime: any;
    const [dataPlayingCenter, setDataPlayingCenter] = useState<any[]>([]);
    const [unitTimeChange, setUnitTimeChange] = useState<any>();
    const [open, setOpen] = useState(false);
    const [unitTimeDetails, setUnitTimeDetails] = useState<UnitTimeOfPlayingCenter>();
    var playingCenter: any;
    const [state, setState] = useState<{
        left: boolean;
        activePopup: 'addUnitTime' | 'editUnitTime' | null;
    }>
        ({
            left: false,
            activePopup: null,
        });
    const [playingCenterData, setPlayingCenterData] = useState<UnitTimeOfPlayingCenter[] | null>(null);
    const value = {
        playingCenterData,
        setPlayingCenterData,
    };
    const [currentUnitTime, setCurrentUnitTime] = useState<UnitTimeOfPlayingCenter | null>(null);
    const currentUnitTimeValue = {
        currentUnitTime,
        setCurrentUnitTime,
    };
    const handleClose = () => {
        setOpen(false);
    };
    const toggleDrawerEditUnitTime = (open: boolean) => {
        setState({ ...state, left: open, activePopup: 'editUnitTime' });
    };
    const listEditUnitTime = (anchor: Anchor) => (
        <Box
            sx={{ width: anchor === 'top' || anchor === 'bottom' ? 'auto' : 250 }}
            role="presentation"
            onClick={() => toggleDrawerEditUnitTime(true)}
            onKeyDown={() => toggleDrawerEditUnitTime(true)}
        >
            <Divider />
        </Box>
    );
    const toggleDrawerAddUnitTime = (open: boolean) => {
        setState({ ...state, left: open, activePopup: 'addUnitTime' });
    };
    const listAddUnitTime = (anchor: Anchor) => (
        <Box
            sx={{ width: anchor === 'top' || anchor === 'bottom' ? 'auto' : 250 }}
            role="presentation"
            onClick={() => toggleDrawerAddUnitTime(true)}
            onKeyDown={() => toggleDrawerAddUnitTime(true)}
        >
            <Divider />
        </Box>
    );
    const getPlayingCenter = async () => {
        return await PlayingCenterService.getPlayingCenter(location.state.communityAdministrationId).then((res: any) => {
            playingCenter = res;
            console.log(playingCenter, "playingCenter");
            return playingCenter;
        })
    }
    const editPlayingCenterTime = async (row: any) => {
        setCurrentUnitTime(row);
        toggleDrawerEditUnitTime(true);
    }
    const checkDelete = (row: any) => {
        debugger
        setUnitTimeChange(row);
        checkDeleteUnitTime = true;
    }
    const deletePlayingCenterTime = async () => {
        if (unitTimeDetails) {
            var res = await PlayingCenterService.deleteUnitTimeOfPlayingCenter(unitTimeDetails.unitTimeId, location.state.userId);
            setUnitTimeChange(res);
        }
    }
    const addUnitTimeOfPlayingCenter = async () => {
        console.log(location.state);
        console.log(dataPlayingCenter, "dataPlayingCenter");
        navigate('/addUnitTimeOfPlayingCenter', { state: location.state })
    }
    useEffect(() => {
        const fetchData = async () => {
            var data = await getPlayingCenter();
            console.log(data, "data");
            setDataPlayingCenter([...data]);
        }

        fetchData();
    }, [unitTimeChange]);
    return (
        <>
            <PlayingCenterContext.Provider value={{ playingCenterData, setPlayingCenterData, currentUnitTime, setCurrentUnitTime }}>
                <div id="body">
                    <ToolbarNavigation></ToolbarNavigation>
                    <img id='iconPlayingCenter' src={iconPlayingCenter} ></img>
                    <h1 id="title">שעות פעילות המשחקיה</h1>
                    <h2 id="subTitle">עדכון ועריכת שעות פעילות המשחקיה</h2>
                    <TableContainer component={Paper}>
                        <Table sx={{ minWidth: 650 }} aria-label="simple table">
                            <TableHead>
                                <TableRow>
                                    <TableCell align="left"></TableCell>
                                    <TableCell align="left"></TableCell>
                                    <TableCell align="left">מפעילה</TableCell>
                                    <TableCell align="left">  שעות פעילות </TableCell>
                                    <TableCell align="left">יום</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {dataPlayingCenter.map((row, i) => (
                                    <TableRow
                                        key={row.unitTimeId}
                                        sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                                    >
                                        <TableCell id="delete" align="left"><a onClick={() => checkDelete(row)}><img src={deleteIcon}></img></a></TableCell>
                                        <TableCell id="edit" align="left"><a onClick={() => editPlayingCenterTime(row)} className="editUnitTimeLink">עריכה</a></TableCell>
                                        <TableCell align="left">{row.operatorName}</TableCell>
                                        <TableCell align="left">{row.beginningTime} - {row.endTime}</TableCell>
                                        <TableCell align="left">{row.day}</TableCell>
                                        {/* <TableCell align="left"><img id='imgCourse' src={`https://localhost:7233/${row.logo}`}></img></TableCell> */}

                                    </TableRow>
                                ))}
                            </TableBody>
                        </Table>
                    </TableContainer>
                </div>
                <div id="popUp">
                    <React.Fragment key={"left"}>
                        <button id="addUnitTimeButton" onClick={() => toggleDrawerAddUnitTime(true)}>להוספת זמנים</button>
                        {state.activePopup === 'addUnitTime' && (
                            <Drawer
                                anchor={"left"}
                                open={state["left"]}
                                onClose={() => toggleDrawerAddUnitTime(false)}
                            >
                                {listAddUnitTime("left")}
                                <img src={close} className='closePageIcon' onClick={() => toggleDrawerAddUnitTime(false)}></img>
                                <AddUnitTimeOfPlayingCenter></AddUnitTimeOfPlayingCenter>
                            </Drawer>
                        )}
                    </React.Fragment>
                    <React.Fragment key={"left"}>
                        {state.activePopup === 'editUnitTime' && (
                            <Drawer
                                anchor={"left"}
                                open={state["left"]}
                                onClose={() => toggleDrawerEditUnitTime(false)}
                            >
                                {listEditUnitTime("left")}
                                <img src={close} className='closePageIcon' onClick={() => toggleDrawerEditUnitTime(false)}></img>
                                <EditingUnitTimeOfPlayingCenter></EditingUnitTimeOfPlayingCenter>
                            </Drawer>
                        )}
                    </React.Fragment>
                </div>
                {unitTimeChange ?
                    <Dialog
                        open={open}
                        onClose={handleClose}
                        aria-labelledby="alert-dialog-title"
                        aria-describedby="alert-dialog-description"
                    >
                        <DialogTitle id="alert-dialog-title" dir="rtl">
                            {"האם אתה בטוח שברצונך למחוק את שעות הפעילות?"}
                        </DialogTitle>
                        <DialogContent>
                            <DialogContentText id="alert-dialog-description" dir="rtl">
                                אם תאשר את המחיקה,שעות הפעילות ימחקו לנצח ולא תהיה אפשרות לשחזר אותן.
                            </DialogContentText>
                        </DialogContent>
                        <DialogActions dir="rtl">
                            <Button onClick={handleClose} autoFocus >אל תמחק</Button>
                            <Button onClick={() => deletePlayingCenterTime()} >
                                בסדר, מוכן
                            </Button>
                        </DialogActions>
                    </Dialog> : null}
            </PlayingCenterContext.Provider>
        </>
    )
}
export default PlayingCenter;
