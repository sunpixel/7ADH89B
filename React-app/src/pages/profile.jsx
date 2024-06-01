import './css//profile.css'
import img from '../assets/IMG_1857.jpg'
import { useState, useEffect } from 'react';
import navBar from './Nav/Navigation';
import Navigation from './Nav/Navigation';


function profile() {
    const [fname, getfname] = useState('Sanych Pixel Gromov')
    const [avggrade, avggetgrade] = useState('5')
    const [university, getuniversity] = useState('Kazakh National University')
    const [speciality, getspeciality] = useState('Computer Science')
    const [id, getid] = useState('1')


    return (
        <div>
            {useEffect(() => {
                fetch(`https://localhost:7128/api/UserInfo/${id}`, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json',
                    }
                })
                    .then(response => response.json())
                    .then(data => {
                        getfname(data.name)
                        avggetgrade(data.grade)
                        getuniversity(data.ut)
                        getspeciality(data.spec)
                    })
            }, [])}

            <div>
                <div className='Navigator'>
                    <Navigation/>
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


export default profile