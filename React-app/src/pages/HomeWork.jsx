import React from 'react'
import Navigation from './Nav/Navigation'
import "./css/HomeWork.css"

function HomeWork() {
  return (
    <>
    <div className='HW'>
      <div className='HW_Container'>
          <div style={{ flexShrink: 0, position: 'absolute', top: '10%', left: 0 }}>
            <Navigation />
          </div>        
      </div>
      <div className='TopPanelBody'>
        <div className='EventNewsBody' id="EventBody">
          <div className='VminText'>События</div>
        </div>
        <div className='NameBody'>
          <div className='VminText'>H.H</div>
        </div>
        <div className='EventNewsBody' id="NewsBody">
          <div className='VminText'>Новости</div>
        </div>
      </div>
      <div className='Grid'>      

        <div className='StickyNote'></div>

      </div>
    </div>
    

    </>
  )
}

export default HomeWork