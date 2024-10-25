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
        { text: "Data Privacy Notice", href: "#" },
        { text: "General Admission Policy", href: "#" },
        { text: "Selection for a Degree Program and Campus", href: "#" },
        { text: "Freshmen Admission Requirements", href: "#" },
        { text: "QCUCAT Procedure", href: "#" },
        { text: "Admissions Guidelines: Classifications", href: "#" },
        { text: "Admissions Guidelines: Qualifications", href: "#" },
        { text: "Program Curriculum", href: "#" },
        { text: "Grading System", href: "#" }
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
        { text: "San Bartolome Campus", href: "#" },
        { text: "Batasan Campus", href: "#" },
        { text: "San Francisco Campus", href: "#" }
    ]);

    // form
    let previousButton = document.getElementById("previousButton");

    if (previousButton) {
        previousButton.addEventListener("click", () => {
            window.history.back();
        });
    }

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