// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let hamburger = document.querySelector('.hamburger');
let navMenu = document.querySelector('.nav-menu');
let college = document.getElementById("CCS");
let popupDiv = document.getElementById('profileDiv');
let filterDiv = document.getElementById('filter-menu');
let academicYear = document.getElementById('academicYear');
let collegeProgram = document.getElementById('collegeProgram');
let section = document.getElementById('section');
let statusDiv = document.getElementById('status');

function toggleMenu() {
    hamburger.classList.toggle('active');
    navMenu.classList.toggle('active');
}

function toggleProgram() {
    college.classList.toggle('active');
}

function toggleProfile() {
    popupDiv.classList.toggle('active');
}
function toggleSave() {
    alert("Saved changes.");
    window.location.href = "/";
}

function toggleFilter() {
    filterDiv.classList.toggle('active');
    removeActiveClassFromAll(academicYear, collegeProgram, section, statusDiv);
}

function toggleAcademicYear() {
    academicYear.classList.toggle('active');
    removeActiveClassFromAll(collegeProgram, section, statusDiv);
}

function toggleCollegeProgram() {
    collegeProgram.classList.toggle('active');
    removeActiveClassFromAll(academicYear, section, statusDiv);
}

function toggleSection() {
    section.classList.toggle('active');
    removeActiveClassFromAll(academicYear, collegeProgram, statusDiv);
}

function toggleStatus() {
    statusDiv.classList.toggle('active');
    removeActiveClassFromAll(academicYear, collegeProgram, section);
}

function removeActiveClassFromAll(...elements) {
    elements.forEach(element => {
        if (element.classList.contains('active')) {
            element.classList.remove('active');
        }
    });
}

document.addEventListener("DOMContentLoaded", () => {
    // form
    let previousButton = document.getElementById("previousButton");

    if (previousButton) {
        previousButton.addEventListener("click", () => {
            window.history.back();
        });
    }
    // hamburger
    function handleHover(mainMenuId, submenuItems) {
        const mainMenu = document.getElementById(mainMenuId);
        const secondUL = document.getElementById('secondUL');
        const thirdUL = document.getElementById('thirdUL');
        function clearSubmenus() {
            secondUL.innerHTML = '';
            thirdUL.innerHTML = '';
            secondUL.style.display = 'none';
            thirdUL.style.display = 'none';
        }
        mainMenu.addEventListener('mouseenter', function () {
            clearSubmenus();

            submenuItems.forEach((item, index) => {
                const li = document.createElement('li');
                const link = document.createElement('a');
                link.href = item.href;
                link.innerHTML = item.text;
                li.appendChild(link);
                secondUL.appendChild(li);

                if (item.submenu && item.submenu.length > 0) {
                    li.addEventListener('mouseenter', function () {
                        thirdUL.innerHTML = ''; 
                        item.submenu.forEach((program, i) => {
                            const programLi = document.createElement('li');
                            const programLink = document.createElement('a');
                            programLink.href = "#";
                            programLink.innerHTML = program;
                            programLi.appendChild(programLink);
                            thirdUL.appendChild(programLi);

                            setTimeout(() => {
                                programLi.classList.add('show');
                            }, i * 100); 
                        });

                        thirdUL.style.display = 'block';
                    });
                }

                setTimeout(() => {
                    li.classList.add('show');
                }, index * 100); 
            });

            secondUL.style.display = 'block';
        });
    }

    handleHover('be_a_QCIAN', [
        { text: "Data Privacy Notice", href: '/BeAQcian/Dpn' },
        { text: "General Admission Policy", href: '/BeAQcian/Gap' },
        { text: "Selection for a Degree Program and Campus", href: '/BeAQcian/Sdc' },
        { text: "Freshmen Admission Requirements", href: '/BeAQcian/Far' },
        { text: "QCUCAT Procedure", href: '/BeAQcian/Qcucat' },
        { text: "Admissions Guidelines: Classifications", href: '/BeAQcian/Agc' },
        { text: "Admissions Guidelines: Qualifications", href: '/BeAQcian/Agq' },
        { text: "Program Curriculum", href: '/BeAQcian/Pc' },
        { text: "Grading System", href: '/BeAQcian/Gs' }
    ]);

    handleHover('programsOffered', [
        {
            text: "College of Business and Accountancy", href: "#", submenu: [
                "Bachelor of Science in Accountancy",
                "Bachelor of Science in Entrepreneurship",
                "Bachelor of Management Accounting"
            ]
        },
        {
            text: "College of Computer Studies", href: "#", submenu: [
                "Bachelor of Science in Computer Science",
                "Bachelor of Science in Information System",
                "Bachelor of Science in Information Technology"
            ]
        },
        {
            text: "College of Education", href: "#", submenu: [
                "Bachelor of Early Childhood Education"
            ]
        },
        {
            text: "College of Engineering", href: "#", submenu: [
                "Bachelor of Science in Industrial Engineering",
                "Bachelor of Science in Electronics Engineering"
            ]
        }
    ]);

    handleHover('contactUs', [
        {
            text: "Office of VP for Academic Affairs<br>DR. BRADFORD ANTONIO C. MARTINEZ", href: "#", submenu: [
                "Contact Number: 8806-3324<br>Email: ovpaa2020@gmail.com"
            ]
        },
        {
            text: "Chief, Admissions<br>MS. ANNIE LOU M. GONZALES", href: "#", submenu: [
                "Contact Number: 8681-9135<br>Email: admission@qcu.edu.ph"
            ]
        },
        {
            text: "Registrar and Admissions Division<br>MS. SHERYL P. MOSTAJO (Registrar)", href: "#", submenu: [
                "Contact Number: 8806-3470<br>Email: registrar@qcu.edu.ph"
            ]
        },
        {
            text: "Student Affairs Division<br>MS. MERLY P. DELA CRUZ", href: "#", submenu: [
                "Contact Number: 8806-3165<br>Email: sasd2020@gmail.com"
            ]
        }
    ]);

    handleHover('campus', [
        { text: "San Bartolome Campus", href: "/BeAQcian/Sb" },
        { text: "Batasan Campus", href: "/BeAQcian/Ba" },
        { text: "San Francisco Campus", href: "/BeAQcian/Sf" }
    ]);

    // OTP
    const inputs = document.querySelectorAll("#otp > *[id]");
    for (let i = 0; i < inputs.length; i++) {
        inputs[i].addEventListener("keydown", function (event) {
            if (event.key === "Backspace") {
                inputs[i].value = "";
                if (i !== 0) inputs[i - 1].focus();
            } else {
                if (i === inputs.length - 1 && inputs[i].value !== "") {
                    return true;
                } else if (event.keyCode > 47 && event.keyCode < 58) {
                    inputs[i].value = event.key;
                    if (i !== inputs.length - 1) inputs[i + 1].focus();
                    event.preventDefault();
                } else if (event.keyCode > 64 && event.keyCode < 91) {
                    inputs[i].value = String.fromCharCode(event.keyCode);
                    if (i !== inputs.length - 1) inputs[i + 1].focus();
                    event.preventDefault();
                }
            }
        });
    }

    // footer
    let date = new Date().getFullYear();
    document.getElementById("year").innerHTML = date;

    // submit image
    const actualBtn = document.getElementById('actual-btn');
    const imageContainer = document.getElementById('image-container');

    if (actualBtn) {
        actualBtn.addEventListener('change', function () {
            const file = this.files[0];

            if (file) {
                const reader = new FileReader();
                reader.onload = function (event) {
                    const imageUrl = event.target.result;
                    const imgElement = document.createElement('img');
                    imgElement.src = imageUrl;
                    imgElement.alt = 'Selected Image';
                    imgElement.style.borderRadius = "inherit";
                    imgElement.style.maxWidth = '100%'; // Ensure the image fits within the container
                    const label = imageContainer.querySelector('label');
                    const span = imageContainer.querySelector('span');
                    if (label) label.remove();
                    if (span) span.remove();
                    const existingImages = imageContainer.querySelectorAll('img');
                    existingImages.forEach(img => img.remove());
                    imageContainer.appendChild(imgElement);
                };
                reader.readAsDataURL(file);
            } else {
                console.log('No file selected');
            }
        });
    }
});

document.addEventListener("click", (e) => {
    if (e.target.id !== "profile_img" && popupDiv.classList.contains("active")) {
        popupDiv.classList.toggle("active");
    }

    document.addEventListener("click", (e) => {
        if (
            !e.target.closest("#filter-menu") &&
            e.target.id !== "filter-anchor" &&
            filterDiv.classList.contains("active")
        ) {
            filterDiv.classList.remove("active");
            removeActiveClassFromAll(academicYear, collegeProgram, section, statusDiv);
        }
    });
});

//Validator//
function setInvalidBackground(inputField) {
    inputField.style.borderColor = 'red';
    inputField.style.backgroundColor = '#ffe6e6'; // Light red background color
}

function setValidBackground(inputField) {
    inputField.style.borderColor = '';
    inputField.style.backgroundColor = ''; // Reset background color
}

///END OF VALIDATOR////

////REGISTER - INDEX////

function toggleTrackStrand(enable) {
    var track = document.getElementById('track');
    var strand = document.getElementById('strand');

    track.disabled = !enable;
    strand.disabled = !enable;

    if (!enable) {
        track.value = "";
        strand.innerHTML = '<option value="" selected disabled>Select Strand</option>';
    } else {
        updateStrandOptions();
    }
}

function updateStrandOptions() {
    var track = document.getElementById('track').value;
    var strand = document.getElementById('strand');
    strand.innerHTML = '';

    if (track === 'Academic') {
        var options = ['Academic (GA)', 'Humanities and Social Sciences (HUMSS)', 'Science, Technology, Engineering and Mathematics (STEM)', 'Accountancy, Business and Management (ABM)'];
    } else if (track === 'Technical-Vocational-Livelihood') {
        var options = ['Home Economics (HE)', 'Industrial Arts (IA)', 'Information and Communications Technology (ICT)'];
    }

    options.forEach(function (optionText) {
        var option = document.createElement('option');
        option.value = optionText.split(' ')[0]; // Use the acronym as the value
        option.textContent = optionText;
        strand.appendChild(option);
    });

    // Set the default strand based on the track
    if (track === 'Academic') {
        strand.value = 'GA';
    } else if (track === 'Technical-Vocational-Livelihood') {
        strand.value = 'HE';
    }
}

// Initialize the state on page load
window.onload = function () {
    var radios = document.getElementsByName('applyingAs');
    var selected = Array.from(radios).find(radio => radio.checked);
    if (selected && selected.value === 'Senior High School Graduate') {
        toggleTrackStrand(true);
    } else {
        toggleTrackStrand(false);
    }
}

////// END REGISTER - INDEX ////


/////ADDRESS////


// district data
const districts = {
    'District 1': ['Alicia', 'Bagong Pag-asa', 'Bahay Toro', 'Balingasa', 'Bungad', 'Damar', 'Damayan', 'Del Monte', 'Katipunan', 'Lourdes', 'Maharlika', 'Manresa', 'Mariblo', 'Masambong', 'N.S. Amoranto (Gintong Silahis)', 'Nayong Kanluran', 'Paang Bundok', 'Pag-ibig sa Nayon', 'Paltok', 'Paraiso', 'Phil-Am', 'Project 6', 'Ramon Magsaysay', 'Saint Peter', 'Salvacion', 'San Antonio', 'San Isidro Labrador', 'San Jose', 'Santa Cruz', 'Santa Teresita', 'Sto. Cristo', 'Santo Domingo (Matalahib)', 'Siena', 'Talayan', 'Vasra', 'Veterans Village', 'West Triangle'],
    'District 2': ['Bagong Silangan', 'Batasan Hills', 'Commonwealth', 'Holy Spirit', 'Payatas'],
    'District 3': ['Amihan', 'Bagumbayan', 'Bagumbuhay', 'Bayanihan', 'Blue Ridge A', 'Blue Ridge B', 'Camp Aguinaldo', 'Claro (Quirino 3-B)', 'Dioquino Zobel', 'Duyan-duyan', 'E. Rodriguez', 'East Kamias', 'Escopa I', 'Escopa II', 'Escopa III', 'Escopa IV', 'Libis', 'Loyola Heights', 'Mangga', 'Marilag', 'Masagana', 'Matandang Balara', 'Milagrosa', 'Pansol', 'Quirino 2-A', 'Quirino 2-B', 'Quirino 2-C', 'Quirino 3-A', 'St. Ignatius', 'San Roque', 'Silangan', 'Socorro', 'Tagumpay', 'Ugong Norte', 'Villa Maria Clara', 'West Kamias', 'White Plains'],
    'District 4': ['Bagong Lipunan ng Crame', 'Botocan', 'Central', 'Damayang Lagi', 'Don Manuel', 'Doña Aurora', 'Doña Imelda', 'Doña Josefa', 'Horseshoe', 'Immaculate Concepcion', 'Kalusugan', 'Kamuning', 'Kaunlaran', 'Kristong Hari', 'Krus na Ligas', 'Laging Handa', 'Malaya', 'Mariana', 'Obrero', 'Old Capitol Site', 'Paligsahan', 'Pinagkaisahan', 'Pinyahan', 'Roxas', 'Sacred Heart', 'San Isidro Galas', 'San Martin de Porres', 'San Vicente', 'Santol', 'Sikatuna Village', 'South Triangle', 'Sto. Niño', 'Tatalon', 'Teacher\'s Village East', 'Teacher\'s Village West', 'U.P. Campus', 'U.P. Village', 'Valencia'],
    'District 5': ['Bagbag', 'Capri', 'Fairview', 'Gulod', 'Greater Lagro', 'Kaligayahan', 'Nagkaisang Nayon', 'North Fairview', 'Novaliches Proper', 'Pasong Putik Proper', 'San Agustin', 'San Bartolome', 'Sta. Lucia', 'Sta. Monica'],
    'District 6': ['Apolonio Samson', 'Baesa', 'Balong Bato', 'Culiat', 'New Era', 'Pasong Tamo', 'Sangandaan', 'Sauyo', 'Talipapa', 'Tandang Sora', 'Unang Sigaw']
};

// Function to populate dropdown options
function populateDropdown(elementId, options) {
    const dropdown = document.getElementById(elementId);
    dropdown.innerHTML = '<option value="" selected disabled>Select Option</option>'; // Reset dropdown

    options.forEach(option => {
        const optionElem = document.createElement('option');
        optionElem.value = option;
        optionElem.textContent = option;
        dropdown.appendChild(optionElem);
    });
}

// Event listener to populate barangay dropdown when district is changed
document.getElementById('district').addEventListener('change', function () {
    const selectedDistrict = this.value;
    if (selectedDistrict && districts[selectedDistrict]) {
        populateDropdown('barangay', districts[selectedDistrict]);
    } else {
        populateDropdown('barangay', []);
    }
});

// Default population of district dropdown
populateDropdown('district', Object.keys(districts));

// Pre-select Quezon City as the default city in the City dropdown
document.getElementById('municipality').value = 'Quezon City';

///END OF ADDRESS////


