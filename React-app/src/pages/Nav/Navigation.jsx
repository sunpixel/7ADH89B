import '../css/Navigation.css'
import { useNavigate } from 'react-router-dom';


function Navigation ()
{
    const navigate = useNavigate();

    const redirect = (path) => {
        navigate(path);
    };

    return (
        <div className='Nav'>
            <div className='Nav_Container'>
                <button id="sb_1" className='Nav_Container-1' onClick={() => redirect('/grades')}>
                    <h2 className='text-align'>GRADES</h2>
                </button>
                <button id="sb_2" className='Nav_Container-1' onClick={() => redirect('/hw')}>
                    <h2 className='text-align'>HW</h2>
                </button>
                <button id="sb_3" className='Nav_Container-1' onClick={() => redirect('/schedule')}>
                    <h2 className='text-align'>SCHEDULE</h2>
                </button>
                <button id="sb_4" className='Nav_Container-1' onClick={() => redirect('/other')}>
                    <h2 className='text-align'>OTHER</h2>
                </button>
                
            </div>            
        </div>
    );
}


export default Navigation