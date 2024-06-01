import './css/profile.css';
import img from '../assets/IMG_1857.jpg';
import { useState, useEffect } from 'react';
import { useLocation } from 'react-router-dom';
import Navigation from './Nav/Navigation';

function Profile() {
    const location = useLocation();
    const { id } = location.state;

    const [fname, getfname] = useState('');
    const [avggrade, avggetgrade] = useState('');
    const [university, getuniversity] = useState('');
    const [speciality, getspeciality] = useState('');

    useEffect(() => {
        fetch(`https://localhost:7128/api/UserInfo/${id}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            }
        })
            .then(response => response.json())
            .then(data => {
                getfname(data.fullName);
                avggetgrade(data.avG_Grade);
                getuniversity(data.university);
                getspeciality(data.speciality);
            })
            .catch(error => console.error("Error fetching user info:", error));
    }, [id]);

    return (
        <div>
            <div>
                <div className='Navigator'>
                    <Navigation />
                </div>
                <div className="Pro_card">
                    <div className='Image'>
                        <img src={img} alt="" style={{ objectFit: 'cover', width: '100%', height: '100%', borderRadius: '50%' }} />
                    </div>
                    <div className='rectangle-16'>
                        <div className='info_Container'>
                            <div className='rectangle-17'>
                                <h2>{fname}</h2>
                            </div>
                            <div className='rectangle-17'>
                                <h2>{avggrade}</h2>
                            </div>
                            <div className='rectangle-17'>
                                <h2>{university}</h2>
                            </div>
                            <div className='rectangle-17'>
                                <h2>{speciality}</h2>
                            </div>
                        </div>
                    </div>
                    <div className='rect'></div>
                </div>
            </div>
        </div>
    );
}

export default Profile;
