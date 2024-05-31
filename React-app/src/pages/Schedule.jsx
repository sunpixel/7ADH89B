import React from 'react'
import Navigation from './Nav/Navigation'

function Schedule() {
  return (
    <>
      <div style={{ display: 'flex', alignItems: 'center' }}>
        <div style={{ flexShrink: 0, position: 'absolute', left: 0 }}>
          <Navigation />
        </div>
        <div style={{ fontSize: '36px' }}>Schedule</div>
      </div>
    </>
  )
}

export default Schedule