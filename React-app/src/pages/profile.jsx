import './profile.css'
import img from '../assets/IMG_1857.jpg'


function profile(){
    return (
        <div className="Pro_card">
            <div className='Image'>
                <img src={img} alt="" style={{ objectFit: 'cover', width: '100%', height: '100%', borderRadius: '50%' }} />
            </div>
            <div className='rectangle-16'>
                <div className='info_Container'>
                    <div className='rectangle-17'></div>
                    <div className='rectangle-17'></div>
                    <div className='rectangle-17'></div>
                    <div className='rectangle-17'></div>
                </div>
            </div>
            <div className='rect'></div>
        </div>
    );
}


export default profile