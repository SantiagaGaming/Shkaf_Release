using AosSdk.Core.Scripts;
using UnityEngine;

namespace AosSdk.Core.Player.Scripts
{
    [AosObject(name:"Игрок")]
    [RequireComponent(typeof(CharacterController))]
    public class Player : AosObjectBase
    {
        [Header("Moving")] [SerializeField] private float walkingSpeed = 7.5f;
        [SerializeField] private float runningSpeed = 11.5f;
        [SerializeField] private float jumpSpeed = 8.0f;
        [SerializeField] private float gravity = 20.0f;
        [SerializeField] private float lookSpeed = 2.0f;
        [SerializeField] private float lookXLimit = 45.0f;

        [Space] [Header("Interaction")] [SerializeField]
        private Color defaultCrossHairColor;
        [SerializeField] private Sprite defaultCrossHairSprite;
        [SerializeField] private Sprite hoveredCrossHairSprite;
        [SerializeField] private float crossHairSizeMultiplier = 1;
        [SerializeField] private float interactDistance = 0.5f;

        [Space] [Header("References")] [SerializeField]
        private CharacterController characterController;

        [SerializeField] private RayCaster rayCaster;
        [SerializeField] private CrossHair crossHair;
        [SerializeField] private Camera playerCamera;

        public static Player Instance;

        private Vector3 _moveDirection = Vector3.zero;
        private float _rotationX;
        private Transform _playerTransform;

        public bool CanMove { get; set; } = true;
        public bool CanRun { get; set; } = true;

        public void TeleportTo(Transform target)
        {
            characterController.enabled = false;
            _playerTransform.position = target.position;
            _playerTransform.rotation = target.rotation;
            characterController.enabled = true;
        }

        [AosAction("Телепортировать игрока в координаты")]
        public void TeleportTo([AosParameter("Координата x")] float x, [AosParameter("Координата y")] float y,
            [AosParameter("Координата z")] float z)
        {
            _playerTransform.position = new Vector3(x, y, z);
        }

        [AosAction("Телепортировать игрока к объекту")]
        public void TeleportTo([AosParameter("Имя объекта")] string objectName)
        {
            var target = GameObject.Find(objectName)?.transform;

            if (!target)
            {
                ReportError($"Teleport to object failed, no object with name {objectName} found");
                return;
            }

            _playerTransform.position = target.position;
            _playerTransform.rotation = target.rotation;
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            _playerTransform = transform;

            rayCaster.InteractDistance = interactDistance;
            rayCaster.CrossHair = crossHair;
            rayCaster.CameraTransform = playerCamera.transform;
            crossHair.CrossHairSizeMultiplier = crossHairSizeMultiplier;
            crossHair.CrossHairDefaultSprite = defaultCrossHairSprite;
            crossHair.CrossHaiHoveredSprite = hoveredCrossHairSprite;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            var forward = transform.TransformDirection(Vector3.forward);
            var right = transform.TransformDirection(Vector3.right);

            var isRunning = Input.GetKey(KeyCode.LeftShift) && CanRun;

            var curSpeedX = CanMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
            var curSpeedY = CanMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
            var movementDirectionY = _moveDirection.y;
            _moveDirection = forward * curSpeedX + right * curSpeedY;

            if (Input.GetButton("Jump") && CanMove && characterController.isGrounded)
            {
                _moveDirection.y = jumpSpeed;
            }
            else
            {
                _moveDirection.y = movementDirectionY;
            }

            if (!characterController.isGrounded)
            {
                _moveDirection.y -= gravity * Time.deltaTime;
            }

            characterController.Move(_moveDirection * Time.deltaTime);

            if (!CanMove)
            {
                return;
            }

            _rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            _rotationX = Mathf.Clamp(_rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        public void EnableCamera(bool value)
        {
            playerCamera.enabled = value;
        }
        public void EnableRayCaster(bool value)
        {
            rayCaster.enabled = value;
        }
    }
}